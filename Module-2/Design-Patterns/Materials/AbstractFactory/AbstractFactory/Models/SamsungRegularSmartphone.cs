namespace AbstractFactory.Models
{
    using System;

    public class SamsungRegularSmartphone : RegularSmarthphone
    {
        public override void Camera()
        {
            Console.WriteLine("Samsung Camera Quality");
        }
    }
}