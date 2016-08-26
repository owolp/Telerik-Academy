namespace Dealership.UnitTests.Models.Vehicle.Mock
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Dealership.Common.Enums;
    using Contracts;

    public class MockedVehicle : Dealership.Models.Vehicle
    {
        public MockedVehicle(string make, string model, decimal price, VehicleType type)
            : base(make, model, price, type)
        {
        }

        public IList<IComment> Comments
        {
            get
            {
                return base.Comments;
            }
        }

        protected override string PrintAdditionalInfo()
        {
            throw new NotImplementedException();
        }
    }
}
