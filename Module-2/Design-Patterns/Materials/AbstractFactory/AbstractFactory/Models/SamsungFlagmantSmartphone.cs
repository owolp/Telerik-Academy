namespace AbstractFactory.Models
{
    using System;

    public class SamsungFlagmantSmartphone : FlagmantSmarthphone
    {
        public override void Display()
        {
            Console.WriteLine("Samsung Display Quality");
        }
    }
}