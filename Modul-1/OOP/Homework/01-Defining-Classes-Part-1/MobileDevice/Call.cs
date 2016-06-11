namespace MobileDevice
{
    using System;
    using System.Text;

    public class Call
    {
        private string dialedNumber;
        private uint duration;

        // constructors
        public Call(DateTime dateTime, string dialedNumber, uint duration)
        {
            this.Date = dateTime.ToShortDateString();
            this.Time = dateTime.ToLongTimeString();
            this.DialedNumber = dialedNumber;
            this.Duration = duration;
        }

        // properties
        public string Date { get; private set; }

        public string Time { get; private set; }

        public string DialedNumber
        {
            get
            {
                return this.dialedNumber;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The dialed number can not be empty.");
                }

                this.dialedNumber = value;
            }
        }

        public uint Duration
        {
            get
            {
                return this.duration;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException("The phone call duration can not be a negative number.");
                }

                this.duration = value;
            }
        }

        // methods
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendFormat("Call made on {0} at {1} to number {2} with duration {3} seconds.", this.Date, this.Time, this.DialedNumber, this.Duration);

            return stringBuilder.ToString();
        }
    }
}