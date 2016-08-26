namespace Student
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Student
    {
        // Fields
        private string firstName;
        private string lastName;
        private ulong facultyNumber;
        private string phoneNumber;
        private string email;
        private List<double> marks;
        private uint groupNumber;
        private uint age;

        // Constructors
        public Student()
        {
            this.Marks = new List<double>();
        }

        public Student(string firstName, string lastName, uint age, ulong facultyNumber, string phoneNumber, string email, uint groupNumber, Group departmentName)
            : this()
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.FacultyNumber = facultyNumber;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.GroupNumber = groupNumber;
            this.Group = departmentName;
        }

        // Properties
        public Group Group { get; set; }

        public uint GroupNumber
        {
            get { return this.groupNumber; }
            set { this.groupNumber = value; }
        }

        public List<double> Marks
        {
            get
            {
                return this.marks;
            }

            set
            {
                this.marks = value;
            }
        }

        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        public string PhoneNumber
        {
            get { return this.phoneNumber; }
            set { this.phoneNumber = value; }
        }

        public ulong FacultyNumber
        {
            get { return this.facultyNumber; }
            set { this.facultyNumber = value; }
        }

        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }

        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }

        public uint Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        // Methods
        public List<Student> FirstBeforeLastName(List<Student> students)
        {
            return students.Where(s => s.FirstName.CompareTo(s.LastName) < 0).ToList();
        }

        public List<Student> AgeRange(List<Student> students, uint min, uint max)
        {
            return students.Where(s => min <= s.Age && s.Age >= max).ToList();
        }

        public List<Student> OrderByFirstAnsLastName(List<Student> students)
        {
            return students.OrderByDescending(s => s.FirstName).ThenByDescending(s => s.LastName).ToList();
        }

        public List<Student> FromGroup(List<Student> students, uint groupNumber)
        {
            return students.Where(s => s.GroupNumber == groupNumber).OrderBy(s => s.FirstName).ToList();
        }

        public List<Student> ExtractByEmailDomain(List<Student> students, string domain)
        {
            return students.Where(s => s.Email.Contains(domain)).ToList();
        }

        public List<Student> ExtractByPhoneNumber(List<Student> students, string prefix)
        {
            return students.Where(s => s.PhoneNumber.StartsWith(prefix)).ToList();
        }

        public void AddMarks(List<double> marks)
        {
            /*
            foreach (var mark in marks)
            {
                this.marks.Add(mark);
            }
            */

            this.marks.AddRange(marks);
        }

        public List<Student> ExtractByMark(List<Student> students, double mark)
        {
            return students.Where(s => s.Marks.Contains(mark)).ToList();
        }

        public List<Student> ExtractByDepartment(List<Student> students, DepartmentName departmentName)
        {
            bool exists;

            exists = Enum.IsDefined(typeof(DepartmentName), departmentName.ToString());

            if (!exists)
            {
                throw new ArgumentException("There is no such department.");
            }

            return students.Where(s => s.Group.DepartmentName == departmentName).ToList();
        }

        public List<uint> GroupByGroupNumber(List<Student> students)
        {
            List<uint> result = new List<uint>();

            var groups = students.GroupBy(s => s.GroupNumber).ToList();

            foreach (var item in groups)
            {
                result.Add(item.Key);
            }

            return result;
        }
    }
}