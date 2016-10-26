namespace AbstractFactory.Models
{
    using Contracts;

    public abstract class RegularSmarthphone : IRegularSmartphone
    {
        public abstract void Camera();
    }
}