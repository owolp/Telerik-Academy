namespace Methods.Models
{
    using System;
    using System.Linq;
    using Common;

    public class Method
    {
        public string NumberToDigit(int number)
        {
            Validator.ValidateNull(
                number,
                string.Format(Constants.ObjectCannotBeNull, "Number"));

            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
            }

            return "Invalid number!";
        }

        public int FindMax(params int[] elements)
        {
            Validator.ValidateIntRange(
                elements.Length,
                Constants.MinArrayLength,
                int.MaxValue,
                string.Format(Constants.NumberMustBePositive, "Elements length", Constants.MinArrayLength, int.MaxValue));

            var maxNummber = elements.Max();

            return maxNummber;
        }

        public string PrintAsNumber(object number, string format)
        {
            var numberAsString = string.Empty;

            if (format == "f")
            {
                numberAsString = string.Format($"{number:F2}");
            }

            if (format == "%")
            {
                numberAsString = string.Format($"{number:P0}");
            }

            if (format == "r")
            {
                numberAsString = string.Format($"{number,8}");
            }

            return numberAsString;
        }

        public double CalcDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt(
                ((x2 - x1) * (x2 - x1)) +
                ((y2 - y1) * (y2 - y1)));

            return distance;
        }
    }
}
