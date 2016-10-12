using SchoolSystem.Framework.Models.Contracts;

namespace SchoolSystem.Framework.Engines.Contracts
{
    public interface ISchoolSystemEngine
    {
        void Start();

        int AddStudent(IStudent student);

        int AddTeacher(ITeacher teacher);

        void RemoveStudent(int id);

        void RemoveTeacher(int id);

        IStudent GetStudentWithId(int id);

        ITeacher GetTeacherWithId(int id);
    }
}