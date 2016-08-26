namespace TimerClass
{
    using System;
    using System.Threading;

    public delegate void TimerEvent();

    public class TimerClass
    {
        // Fields
        private int miliSeconds;
        private byte ticks;
        private TimerEvent timeEvent;

        // Constructors
        public TimerClass(byte ticks, int interval, TimerEvent timeEvent)
        {
            this.Ticks = ticks;
            this.Interval = interval;
            this.Event = timeEvent;
        }

        // Properties
        public byte Ticks
        {
            get
            {
                return this.ticks;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException();
                }

                this.ticks = value;
            }
        }

        public TimerEvent Event
        {
            get
            {
                return this.timeEvent;
            }

            set
            {
                this.timeEvent = value;
            }
        }

        public int Interval
        {
            get
            {
                return this.miliSeconds;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }

                this.miliSeconds = value * 1000;
            }
        }

        public void Run()
        {
            while (this.ticks > 0)
            {
                Thread.Sleep((int)this.miliSeconds);
                --this.ticks;
                this.timeEvent();
            }
        }
    }
}
