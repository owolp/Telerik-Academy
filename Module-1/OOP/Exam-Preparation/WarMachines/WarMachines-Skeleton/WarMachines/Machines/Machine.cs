namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using System.Text;
    public abstract class Machine : IMachine
    {
        private string name;
        private IPilot pilot;
        private ICollection<string> targets;

        public Machine(string name, double attackPoints, double defensePoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.Pilot = null;
            this.Targets = new List<string>();
        }

        public double AttackPoints { get; set; }

        public double DefensePoints { get; set; }

        public double HealthPoints { get; set; }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                Validator.CheckIfStringIsNullOrEmpty(
                    value,
                    string.Format(
                        ErrorMessages.StringCannotBeNullOrEmpty,
                        this.GetType().Name + " name"));

                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }

            set
            {
                //Validator.CheckIfNull(
                //    value,
                //    string.Format(ErrorMessages.ObjectCannotBeNull, "Pilot"));

                this.pilot = value;
            }
        }

        public IList<string> Targets { get; set; }

        public void Attack(string target)
        {
            Validator.CheckIfNull(
                target,
                string.Format(ErrorMessages.ObjectCannotBeNull, "Target"));

            this.targets.Add(target);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(
                string.Format(
                    "- {0}", this.Name));
            result.AppendLine(
                string.Format(
                    " *Type: {0}", this.GetType().Name));
            result.AppendLine(
                string.Format(
                    " *Health: {0}", this.HealthPoints));
            result.AppendLine(
                string.Format(
                    " *Attack: {0}", this.AttackPoints));
            result.AppendLine(
                string.Format(
                    " *Defense: {0}", this.DefensePoints));
            result.AppendLine(
                string.Format(
                    " *Targets: {0}", this.Targets.Count < 1 ? "None" : string.Join(", ", this.Targets)));

            return result.ToString().Trim();
        }
    }
}
