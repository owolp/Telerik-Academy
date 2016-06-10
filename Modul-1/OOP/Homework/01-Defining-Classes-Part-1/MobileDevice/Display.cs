namespace MobileDevice
{
    using System;
    using System.Text;

    public class Display
    {
        // fields
        private double? size;
        private ulong? numberOfColors;

        // constructors
        public Display()
        {
            this.Size = null;
            this.NumberOfColors = null;
        }

        public Display(double? size) : this()
        {
            this.Size = size;
        }

        public Display(double? size, ulong? numberOfColors) : this(size)
        {
            this.NumberOfColors = numberOfColors;
        }

        // properties
        public double? Size
        {
            get
            {
                return this.size;
            }

            private set
            {
                if (this.size < 2)
                {
                    throw new ArgumentOutOfRangeException("The display size can not be less than 2 inches.");
                }
                else
                {
                    this.size = value;
                }               
            }
        }

        public ulong? NumberOfColors
        {
            get
            {
                return this.numberOfColors;
            }

            private set
            {
                if (this.numberOfColors < 1)
                {
                    throw new ArgumentOutOfRangeException("Nokia 3310 RLZ!");
                }
                else
                {
                    this.numberOfColors = value;
                }
            }
        }

        // methods
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("-=Display details=-");

            if (this.Size != null)
            {
                stringBuilder.AppendLine()
                    .AppendFormat("Size: {0}", this.Size);
            }

            if (this.NumberOfColors != null)
            {
                stringBuilder.AppendLine()
                    .AppendFormat("Number of Colors: {0}", this.NumberOfColors);
            }

            return stringBuilder.ToString();
        }
    }
}