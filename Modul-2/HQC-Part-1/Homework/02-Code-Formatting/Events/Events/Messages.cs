namespace Events
{
    using System.Text;

    public static class Messages
    {
        static Messages()
        {
            var output = new StringBuilder();
        }

        public static StringBuilder Output { get; private set; }

        public static void EventAdded()
        {
            Output.AppendLine("Event added");
        }

        public static void EventDeleted(int numberOfEvents)
        {
            if (numberOfEvents == 0)
            {
                NoEventsFound();
            }
            else
            {
                Output.AppendLine(string.Format($"{numberOfEvents} events deleted"));
            }
        }

        public static void NoEventsFound()
        {
            Output.AppendLine("No events found");
        }

        public static void PrintEvent(Event eventToPrint)
        {
            if (eventToPrint != null)
            {
                Output.AppendLine(eventToPrint.ToString());
            }
        }
    }
}