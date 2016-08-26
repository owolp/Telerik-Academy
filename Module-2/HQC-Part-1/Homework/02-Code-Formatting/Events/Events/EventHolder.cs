namespace Events
{
    using System;
    using Wintellect.PowerCollections;

    public class EventHolder
    {
        private MultiDictionary<string, Event> addByTitle = new MultiDictionary<string, Event>(true);
        private OrderedBag<Event> addByDate = new OrderedBag<Event>();

        public void AddEvent(DateTime date, string title, string location)
        {
            Event newEvent = new Event(date, title, location);

            this.addByTitle.Add(title.ToLower(), newEvent);
            this.addByDate.Add(newEvent);

            Messages.EventAdded();
        }

        public void DeleteEvents(string titleToDelete)
        {
            string titleToLower = titleToDelete.ToLower();
            int removed = 0;

            var eventsToRemove = this.addByTitle[titleToLower];

            foreach (var eventToRemove in eventsToRemove)
            {
                this.addByDate.Remove(eventToRemove);
                removed++;
            }

            this.addByTitle.Remove(titleToLower);

            Messages.EventDeleted(removed);
        }

        public void ListEvents(DateTime date, int count)
        {
            var eventType = new Event(date, string.Empty, string.Empty);
            OrderedBag<Event>.View eventsToShow = this.addByDate.RangeFrom(eventType, true);

            int showed = 0;
            foreach (var eventToShow in eventsToShow)
            {
                if (showed == count)
                {
                    break;
                }

                Messages.PrintEvent(eventToShow);

                showed++;
            }

            if (showed == 0)
            {
                Messages.NoEventsFound();
            }
        }
    }
}