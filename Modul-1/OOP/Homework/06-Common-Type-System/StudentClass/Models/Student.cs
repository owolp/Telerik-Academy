namespace StudentClass.Models
{
    using System;
    using System.Collections;
    using System.Text;
    using Enumerators;
    using Interfaces;

    public class Student : IEnumerable, ICloneable<Student>, IComparable
    {
        public Student(
            string firstName,
            string middleName, 
            string lastName,
            int ssn,
            string permanentAddress,
            string mobilePhoneNumbers,
            string email,
            int course,
            Specialty speciality,
            University university,
            Faculty faculty)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Ssn = ssn;
            this.PermanentAddress = permanentAddress;
            this.MobilePhoneNumber = mobilePhoneNumbers;
            this.Email = email;
            this.Specialty = speciality;
            this.University = university;
            this.Faculty = faculty;
        }

        public string FirstName { get; private set; }

        public string MiddleName { get; private set; }

        public string LastName { get; private set; }

        public int Ssn { get; private set; }

        public string PermanentAddress { get; private set; }

        public string MobilePhoneNumber { get; private set; }

        public string Email { get; private set; }

        public int Course { get; private set; }

        public Specialty Specialty { get; private set; }

        public University University { get; private set; }

        public Faculty Faculty { get; private set; }

        public static bool operator ==(Student firstStudent, Student secondStudent)
        {
            return firstStudent.Equals(secondStudent);
        }

        public static bool operator !=(Student firstStudent, Student secondStudent)
        {
            return !firstStudent.Equals(secondStudent);
        }

        public override bool Equals(object obj)
        {
            var firstNameEquals = this.FirstName.Equals((obj as Student).FirstName);
            var middleNameEquals = this.MiddleName.Equals((obj as Student).MiddleName);
            var lastNameEquals = this.LastName.Equals((obj as Student).LastName);
            var ssnEquals = this.Ssn.Equals((obj as Student).Ssn);
            var permanentAddressEquals = this.PermanentAddress.Equals((obj as Student).PermanentAddress);
            var mobilePhoneNumberEquals = this.MobilePhoneNumber.Equals((obj as Student).MobilePhoneNumber);
            var emailEquals = this.Email.Equals((obj as Student).Email);
            var courseEquals = this.Course.Equals((obj as Student).Course);
            var specialtyEquals = this.Specialty.Equals((obj as Student).Specialty);
            var universityEquals = this.University.Equals((obj as Student).University);
            var facultyEquals = this.Faculty.Equals((obj as Student).Faculty);

            if (firstNameEquals 
                && middleNameEquals 
                && lastNameEquals 
                && ssnEquals 
                && permanentAddressEquals 
                && mobilePhoneNumberEquals
                && emailEquals 
                && courseEquals
                && specialtyEquals 
                && universityEquals 
                && facultyEquals)
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            Random random = new Random();
            int hash = 7;

            hash = (random.Next(1, 20) * hash) + this.Ssn.GetHashCode();
            hash = (random.Next(1, 20) * hash) + this.Course.GetHashCode();

            return hash;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(string.Format("{0} {1} {2}", this.FirstName, this.MiddleName, this.LastName));
            result.AppendLine(string.Format("SSN: {0}", this.Ssn));
            result.AppendLine(string.Format("Permanent Address: {0}", this.PermanentAddress));
            result.AppendLine(string.Format("Mobile Phone Number: {0}", this.MobilePhoneNumber));
            result.AppendLine(string.Format("Email: {0}", this.Email));
            result.AppendLine(string.Format("Course: {0}", this.Course));
            result.AppendLine(string.Format("Specialty: {0}", this.Specialty));
            result.AppendLine(string.Format("University: {0}", this.University));
            result.AppendLine(string.Format("Faculty: {0}", this.Faculty));

            return result.ToString();
        }

        public IEnumerator GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public object Clone()
        {
            return new Student(
                this.FirstName,
                this.MiddleName,
                this.LastName,
                this.Ssn,
                this.PermanentAddress,
                this.MobilePhoneNumber,
                this.Email,
                this.Course,
                this.Specialty,
                this.University,
                this.Faculty);
        }

        public int CompareTo(object obj)
        {
            if (this.FirstName.CompareTo((obj as Student).FirstName) != 0)
            {
                return this.FirstName.CompareTo((obj as Student).FirstName);
            }

            if (this.MiddleName.CompareTo((obj as Student).MiddleName) != 0)
            {
                return this.MiddleName.CompareTo((obj as Student).MiddleName);
            }

            if (this.LastName.CompareTo((obj as Student).LastName) != 0)
            {
                return this.LastName.CompareTo((obj as Student).LastName);
            }

            if (this.Ssn.CompareTo((obj as Student).Ssn) != 0)
            {
                return this.Ssn.CompareTo((obj as Student).Ssn);
            }

            return 0;
        }
    }
}