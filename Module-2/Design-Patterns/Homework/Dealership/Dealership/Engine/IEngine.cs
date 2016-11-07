namespace Dealership.Engine
{
    using System.Collections.Generic;
    using Dealership.Contracts;

    public interface IEngine
    {
        void Start();

        void Reset();

        IUser LoggedUser { get; set; }

        ICollection<IUser> Users { get; }
    }
}
