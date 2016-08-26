namespace Events
{
    using System;
    using System.Text;

    public class Event : IComparable
    {
        private const string Pipe = " | ";

        public Event(DateTime date, string title, string location)
        {
            this.Date = date;
            this.Title = title;
            this.Location = location;
        }

        public DateTime Date { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public int CompareTo(object obj)
        {
            Event objAsEvent = obj as Event;

            int compareByDate = this.Date.CompareTo(objAsEvent.Date);
            int compareByTitle = this.Title.CompareTo(objAsEvent.Title);
            int compareByLocation = this.Location.CompareTo(objAsEvent.Location);

            if (compareByDate == 0 && compareByTitle == 0)
            {
                return compareByLocation;
            }
            else if (compareByDate == 0)
            {
                return compareByTitle;
            }
            else
            {
                return compareByDate;
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(this.Date.ToString("yyyy-MM-ddTHH:mm:ss"));
            stringBuilder.Append(Pipe + this.Title);

            var locationIsNotNull = this.Location != null;
            var locationIsNotEmpty = this.Location != string.Empty;

            if (locationIsNotNull && locationIsNotEmpty)
            {
                stringBuilder.Append(Pipe + this.Location);
            }

            return stringBuilder.ToString();
        }
    }
}