using SchoolSystem.Framework.Models.Abstract;
using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Framework.Models
{
    public class Teacher : Person, ITeacher
    {
        private readonly SchoolSubjectType subject;

        public Teacher(string firstName, string lastName, SchoolSubjectType subject)
                : base(firstName, lastName)
        {
            this.subject = subject;
        }

        public SchoolSubjectType SchoolSubjectType { get; set; }

        public void AddMark(IStudent student, IMark mark)
        {
            mark.SchoolSubjectType = this.subject;
            student.AddMark(mark);
        }
    }
}
