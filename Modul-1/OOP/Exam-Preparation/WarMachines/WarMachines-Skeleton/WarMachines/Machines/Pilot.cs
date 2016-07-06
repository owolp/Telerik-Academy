namespace WarMachines.Machines
{
    using System;
    using Interfaces;
    using System.Collections.Generic;
    using System.Text;
    public class Pilot : IPilot
    {
        private string name;
        private ICollection<IMachine> machines;

        public Pilot(string name)
        {
            this.Name = name;
            this.machines = new List<IMachine>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validator.CheckIfStringIsNullOrEmpty(
                    value,
                    string.Format(
                        ErrorMessages.StringCannotBeNullOrEmpty,
                        this.GetType().Name + " name"));

                this.name = value;
            }
        }

        public void AddMachine(IMachine machine)
        {
            Validator.CheckIfNull(
                machine,
                string.Format(ErrorMessages.ObjectCannotBeNull, "Machine"));

            this.machines.Add(machine);
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();

            var numberOfMachines = string.Empty;
            if (this.machines.Count == 0)
            {
                numberOfMachines = "no machines";
            }
            else if (this.machines.Count == 1)
            {
                numberOfMachines = "1 machine";
            }
            else
            {
                numberOfMachines = string.Format(this.machines.Count + " machines");
            }


            result.AppendLine(
                string.Format(
                    "{0} - {1}",
                    this.Name,
                    numberOfMachines));

            foreach (var machine in machines)
            {
                result.AppendLine(machine.ToString());
            }

            return result.ToString().Trim();
        }
    }
}
