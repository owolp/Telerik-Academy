namespace WarMachines.Machines
{
    using Interfaces;
    using System.Collections.Generic;
    using System;
    using System.Text;
    public class Fighter : Machine, IFighter
    {
        private const int InitialHealthPoints = 200;

        private bool mode;

        public Fighter(string name, double attackPoints, double defensePoints, bool stealthMode)
            : base(name, attackPoints, defensePoints)
        {
            this.HealthPoints = InitialHealthPoints;
            this.StealthMode = stealthMode;
        }

        public bool StealthMode
        {
            get
            {
                return this.mode;
            }

            private set
            {
                Validator.CheckIfNull(
                    value,
                    string.Format(ErrorMessages.ObjectCannotBeNull, "StealthMode"));

                this.mode = value;
            }
        }

        public void ToggleStealthMode()
        {
            this.mode = !this.mode;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(base.ToString());
            result.AppendLine(
                string.Format(
                    " *Stealth: {0}", this.StealthMode == true ? "ON" : "OFF"));

            return result.ToString().Trim();
        }
    }
}
