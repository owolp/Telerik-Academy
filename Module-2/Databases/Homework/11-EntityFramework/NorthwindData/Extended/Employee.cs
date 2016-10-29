namespace NorthwindData
{
    using System.Data.Linq;

    public partial class Employee
    {
        public EntitySet<Territory> CorrespondingTerritories
        {
            get
            {
                var result = new EntitySet<Territory>();
                result.Assign(this.Territories);

                return result;
            }
        }
    }
}