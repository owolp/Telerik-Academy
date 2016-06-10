namespace MobileDevice
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Gsm
    {
        // static field for iPhone4S
        public static readonly Gsm IPhone4S = new Gsm("iPhone 4S", "Apple", 650, "John", new Display(4.5, 1000000), new Battery(BatteryType.LiIon, 100, 50));

        // fields
        private const double CallPrice = 0.37;

        private string model;
        private string manufacturer;
        private double? price;
        private string owner;
        private List<Call> callHistory = new List<Call>();

        // constructors
        public Gsm(string model, string manufacturer)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = null;
            this.Owner = null;
            this.Display = null;
            this.Battery = null;
        }

        public Gsm(string model, string manufacturer, double? price)
            : this(model, manufacturer)
        {
            this.Price = price;
        }

        public Gsm(string model, string manufacturer, double? price, string owner)
            : this(model, manufacturer, price)
        {
            this.Owner = owner;
        }

        public Gsm(string model, string manufacturer, double? price, string owner, Display display)
            : this(model, manufacturer, price, owner)
        {
            this.Display = display;
        }

        public Gsm(string model, string manufacturer, double? price, string owner, Display display, Battery battery)
            : this(model, manufacturer, price, owner, display)
        {
            this.Battery = battery;
        }

        // properties
        public string Model
        {
            get
            {
                return this.model;
            }

            private set
            {
                if (value.Length < 2)
                {
                    throw new ArgumentException("Model name can not be less than 2 characters long.");
                }
                else
                {
                    this.model = value;
                }
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }

            private set
            {
                if (value.Length < 2)
                {
                    throw new ArgumentException("Manufacturer name can not be less than 2 characters long.");
                }
                else
                {
                    this.manufacturer = value;
                }
            }
        }

        public double? Price
        {
            get
            {
                return this.price;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price can not be a negative number.");
                }
                else
                {
                    this.price = value;
                }
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }

            set
            {
                this.owner = value;
            }
        }

        public Display Display { get; private set; }

        public Battery Battery { get; private set; }

        public List<Call> CallHistory
        {
            get
            {
                return this.callHistory;
            }
        }

        // methods
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("-=Smartphone details=-")
                .AppendLine()
                .AppendFormat("Model: {0}", this.Model)
                .AppendLine()
                .AppendFormat("Manufacturer: {0}", this.Manufacturer);

            if (this.Price != null)
            {
                stringBuilder.AppendLine()
                    .AppendFormat("Price: {0}", this.Price);
            }

            if (this.Owner != null)
            {
                stringBuilder.AppendLine()
                    .AppendFormat("Owner: {0}", this.Owner);
            }

            if (this.Display != null)
            {
                stringBuilder.AppendLine()
                    .Append(this.Display.ToString());
            }

            if (this.Battery != null)
            {
                stringBuilder.AppendLine()
                    .Append(this.Battery.ToString());
            }

            stringBuilder.AppendLine()
                .Append(new string('-', 100));

            return stringBuilder.ToString();
        }

        public void AddCall(Call call)
        {
            this.callHistory.Add(call);
        }

        public void DeleteCall(Call call)
        {
            this.callHistory.Remove(call);
        }

        public void ClearHistory()
        {
            this.callHistory.Clear();
        }

        public double TotalCallPrice()
        {
            double totalPrice = 0;

            foreach (var call in this.callHistory)
            {
                totalPrice += call.Duration * CallPrice;
            }

            return totalPrice;
        }

        public List<Call> CallHistoryInformation()
        {
            return this.callHistory;
        }
    }
}