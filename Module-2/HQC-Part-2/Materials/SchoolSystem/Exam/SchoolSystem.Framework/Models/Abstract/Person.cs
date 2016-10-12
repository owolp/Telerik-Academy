using System;

using SchoolSystem.Framework.Models.Contracts;

namespace SchoolSystem.Framework.Models.Abstract
{
    public abstract class Person : IPerson
    {
        private string firstName;
        private string lastName;

        protected Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(this.FirstName));
                }

                var isValidName = this.ValidateName(value);
                if (!isValidName)
                {
                    throw new ArgumentException(nameof(this.FirstName));
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(this.LastName));
                }

                var isValidName = this.ValidateName(value);
                if (!isValidName)
                {
                    throw new ArgumentException(nameof(this.LastName));
                }

                this.lastName = value;
            }
        }

        private bool ValidateName(string name)
        {
            var isValid = true;

            var nameLength = name.Length;
            if (!(nameLength >= 2 && nameLength <= 31))
            {
                isValid = false;
            }
            else
            {
                foreach (var chr in name)
                {
                    var charIsLetter = char.IsLetter(chr);
                    if (!charIsLetter)
                    {
                        isValid = false;
                        break;
                    }
                }
            }

            return isValid;
        }
    }
}
