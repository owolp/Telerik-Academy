namespace WarMachines.Machines
{
    using Interfaces;
    using System.Collections.Generic;
    using System.Text;
    public class Tank : Machine, ITank
    {
        private const int InitialHealthPoints = 100;
        private const int AttackPointsChange = 40;
        private const int DefensePointsChange = 30;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints)
        {
            this.HealthPoints = InitialHealthPoints;
            this.DefensePoints += DefensePointsChange;
            this.AttackPoints -= AttackPointsChange;
            this.DefenseMode = true;
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            this.DefenseMode = !this.DefenseMode;
            if (this.DefenseMode)
            {
                this.DefensePoints += DefensePointsChange;
                this.AttackPoints -= AttackPointsChange;
            }
            else
            {
                this.DefensePoints -= DefensePointsChange;
                this.AttackPoints += AttackPointsChange;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(base.ToString());
            result.AppendLine(
                string.Format(
                    " *Defense: {0}", this.DefenseMode == true ? "ON" : "OFF"));

            return result.ToString().Trim();
        }
    }
}
