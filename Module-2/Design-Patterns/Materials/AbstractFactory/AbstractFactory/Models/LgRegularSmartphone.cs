namespace AbstractFactory.Models
{
    using System;

    public class LgRegularSmartphone : RegularSmarthphone
    {
        public override void Camera()
        {
            Console.WriteLine("LG Camera Quality");
        }
    }
}