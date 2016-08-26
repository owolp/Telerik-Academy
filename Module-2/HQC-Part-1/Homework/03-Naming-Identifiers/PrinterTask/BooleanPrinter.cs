namespace PrinterTask
{
    using System;

    public class BooleanPrinter
    {
        private const int MaxCount = 6;

        public static void ReadInput()
        {
            var booleanPrinter = new BooleanPrinter();
            booleanPrinter.Print(true);
        }

        public void Print(bool value)
        {
            Console.WriteLine(value);
        }
    }
}