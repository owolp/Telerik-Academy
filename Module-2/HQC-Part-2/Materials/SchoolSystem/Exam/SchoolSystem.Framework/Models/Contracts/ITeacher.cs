using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Framework.Models.Contracts
{
    public interface ITeacher : IPerson
    {
        SchoolSubjectType SchoolSubjectType { get; set; }

        void AddMark(IStudent student, IMark mark);
    }
}
