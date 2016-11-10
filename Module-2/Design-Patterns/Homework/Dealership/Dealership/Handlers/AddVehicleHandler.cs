namespace Dealership.Handlers
{
    using System;
    using Base;
    using Common.Enums;
    using Dealership.Contracts;
    using Engine;
    using Factories;

    public class AddVehicleHandler : BaseHandler
    {
        private const string AddVehicleCommand = "AddVehicle";
        private const string VehicleAddedSuccessfully = "{0} added vehicle successfully!";

        private IDealershipFactory factory;

        public AddVehicleHandler(IDealershipFactory factory)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("Factory Is Null");
            }

            this.factory = factory;
        }

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == AddVehicleCommand;
        }

        protected override string Handle(ICommand command, IEngine engine)
        {
            var type = command.Parameters[0];
            var make = command.Parameters[1];
            var model = command.Parameters[2];
            var price = decimal.Parse(command.Parameters[3]);
            var additionalParam = command.Parameters[4];

            var typeEnum = (VehicleType)Enum.Parse(typeof(VehicleType), type, true);

            IVehicle vehicle = null;

            if (typeEnum == VehicleType.Car)
            {
                vehicle = this.factory.CreateCar(make, model, price, int.Parse(additionalParam));
            }
            else if (typeEnum == VehicleType.Motorcycle)
            {
                vehicle = this.factory.CreateMotorcycle(make, model, price, additionalParam);
            }
            else if (typeEnum == VehicleType.Truck)
            {
                vehicle = this.factory.CreateTruck(make, model, price, int.Parse(additionalParam));
            }

            engine.LoggedUser.AddVehicle(vehicle);

            return string.Format(VehicleAddedSuccessfully, engine.LoggedUser.Username);
        }
    }
}
