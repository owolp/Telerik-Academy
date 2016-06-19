namespace Student
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Group
    {
        // Fields
        private uint groupNumber;
        private DepartmentName departmentName;

        // Constructors
        public Group(DepartmentName departmentName)
        {
            this.DepartmentName = departmentName;
        }

        // Properties
        public uint GroupNumber
        {
            get { return this.groupNumber; }
            set { this.groupNumber = value; }
        }

        public DepartmentName DepartmentName
        {
            get { return this.departmentName; }
            set { this.departmentName = value; }
        }
    }
}
