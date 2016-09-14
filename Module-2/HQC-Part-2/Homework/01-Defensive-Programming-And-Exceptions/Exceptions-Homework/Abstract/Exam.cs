namespace ExceptionsHomework.Abstract
{
    using Contracts;
    using Models;

    public abstract class Exam : IExam
    {
        public abstract ExamResult Check();
    }
}