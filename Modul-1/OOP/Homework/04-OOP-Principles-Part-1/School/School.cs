namespace School
{
    using System.Collections.Generic;
    using Models;

    public class School
    {
        private List<Student> students;
        private List<Teacher> teachers;

        public School(string name)
        {
            this.Name = name;
            this.students = new List<Student>();
            this.teachers = new List<Teacher>();
        }

        //public List<Student> Students
        //{
        //    get
        //    {
        //        // 01 in order the list of students not to be modified from outside
        //        return new List<Student>(this.students);
        //    }
        //}

        //public List<Teacher> Teachers
        //{
        //    get
        //    {
        //        // 02 in order the list of teachers not to be modified from outside
        //        return new List<Teacher>(this.teachers);
        //    }
        //}

        public string Name { get; private set; }

        // 01
        public void AddStudent(Student student)
        {
            this.students.Add(student);
        }

        // 02
        public void AddTeacher(Teacher teacher)
        {
            this.teachers.Add(teacher);
        }
    }
}
