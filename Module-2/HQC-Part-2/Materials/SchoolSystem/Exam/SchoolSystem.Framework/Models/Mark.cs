using System;

using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Framework.Models
{
    public class Mark : IMark
    {
        private float value;

        public Mark(SchoolSubjectType subject, float value)
        {
            this.SchoolSubjectType = subject;
            this.Value = value;
        }

        public Mark(float value)
        {
            this.Value = value;
        }

        public SchoolSubjectType SchoolSubjectType { get; set; }

        public float Value
        {
            get
            {
                return this.value;
            }

            set
            {
                if (value < 2 || value > 6)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.Value));
                }

                this.value = value;
            }
        }
    }
}
