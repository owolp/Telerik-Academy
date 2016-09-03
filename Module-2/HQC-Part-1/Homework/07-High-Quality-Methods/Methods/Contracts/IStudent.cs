namespace Methods.Contracts
{
    using System;
    using Models;

    public interface IStudent
    {
        bool IsOlderThan(Student comparedStudent);

        DateTime GetBirthDay(Student student);
    }
}
