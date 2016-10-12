using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Framework.Models.Contracts
{
    public interface IMark
    {
        SchoolSubjectType SchoolSubjectType { get; set; }

        float Value { get; set; }
    }
}