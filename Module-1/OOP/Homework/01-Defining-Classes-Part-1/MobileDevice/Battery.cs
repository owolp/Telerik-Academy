﻿namespace MobileDevice
{
    using System;
    using System.Text;

    public class Battery
    {
        // fields
        private int? hoursIdle;
        private int? hoursTalk;
        private BatteryType model;

        // constructors
        public Battery(BatteryType model)
        {
            this.Model = model;
            this.HoursIdle = null;
            this.HoursTalk = null;
        }

        public Battery(BatteryType model, int? hoursTalk, int? hoursIdle) : this(model)
        {
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
        }

        // properties
        public BatteryType Model
        {
            get
            {
                return this.model;
            }

            private set
            {
                this.model = value;
            }
        }

        public int? HoursIdle
        {
            get
            {
                return this.hoursIdle;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The idle time can not be a negative number.");
                }

                this.hoursIdle = value;
            }
        }

        public int? HoursTalk
        {
            get
            {
                return this.hoursTalk;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The talk time can not be a negative number.");
                }

                this.hoursTalk = value;
            }
        }

        // methods
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("-=Battery Details=-")
                .AppendLine(string.Format("Model: {0}", this.Model));

            if (this.HoursIdle != null)
            {
                stringBuilder.AppendLine(string.Format("Hours Idle: {0}", this.HoursIdle));
            }

            if (this.HoursTalk != null)
            {
                stringBuilder.AppendLine(string.Format("Hours Talk: {0}", this.HoursTalk));
            }

            return stringBuilder.ToString();
        }
    }
}