using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Framework.Models.Contracts
{
    public interface IStudent : IPerson
    {
        Grade Grade { get; }

        void AddMark(IMark mark);

        string ListMarks();
    }
}
