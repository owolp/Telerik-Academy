namespace AbstractionConsoleClient
{
    using System;
    using Abstraction.Models;

    public class StartUp
    {
        public static void Main()
        {
            var circle = new Circle(5);
            Console.WriteLine(circle);

            var rectangle = new Rectangle(2, 3);
            Console.WriteLine(rectangle);
        }
    }
}
