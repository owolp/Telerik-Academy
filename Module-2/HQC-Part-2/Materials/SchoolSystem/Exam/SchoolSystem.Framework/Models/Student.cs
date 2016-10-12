using System;
using System.Collections.Generic;
using System.Text;

using SchoolSystem.Framework.Models.Abstract;
using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Framework.Models
{
    public class Student : Person, IStudent
    {
        private readonly IList<IMark> marks;

        private Grade grade;

        public Student(string firstName, string lastName, Grade grade)
                : base(firstName, lastName)
        {
            this.Grade = grade;
            this.marks = new List<IMark>();
        }

        public Grade Grade
        {
            get
            {
                return this.grade;
            }

            private set
            {
                var intValue = (int)value;
                if (intValue < 1 || intValue > 12)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.Grade));
                }

                this.grade = value;
            }
        }

        public void AddMark(IMark mark)
        {
            if (mark == null)
            {
                throw new ArgumentNullException(nameof(mark));
            }

            if (this.marks.Count == 20)
            {
                throw new ArgumentOutOfRangeException("Each student can have a maximum of 20 marks.");
            }

            this.marks.Add(mark);
        }

        public string ListMarks()
        {
            if (this.marks.Count == 0)
            {
                return "This student has no marks.";
            }
            else
            {
                var studentMarksListBuilder = new StringBuilder();
                foreach (var mark in this.marks)
                {
                    studentMarksListBuilder.AppendLine($"{mark.SchoolSubjectType} => {mark.Value}");
                }

                return studentMarksListBuilder.ToString().Trim();
            }
        }
    }
}
