namespace ExceptionsHomework.Contracts
{
    using System.Collections.Generic;
    using Models;

    public interface IStudent
    {
        IList<ExamResult> CheckExams();

        double CalcAverageExamResultInPercents();
    }
}
