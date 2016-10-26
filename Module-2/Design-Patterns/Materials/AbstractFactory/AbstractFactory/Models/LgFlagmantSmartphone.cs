namespace AbstractFactory.Models
{
    using System;

    public class LgFlagmantSmartphone : FlagmantSmarthphone
    {
        public override void Display()
        {
            Console.WriteLine("LG Display Quality");
        }
    }
}