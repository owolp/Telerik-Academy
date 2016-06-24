namespace School.Models
{
    using System.Collections.Generic;
    using Enumerators;
    using Interfaces;

    public class Class : ICommentable
    {
        public Class()
        {
            this.Students = new List<Student>();
            this.Teachers = new List<Teacher>();
        }

        public Class(ClassId uniqueTextId)
            : this()
        {
            this.UniqueTextId = uniqueTextId;
        }

        public IEnumerable<Student> Students { get; private set; }

        public IEnumerable<Teacher> Teachers { get; private set; }

        public string CommentBox { get; private set; }

        public ClassId UniqueTextId { get; private set; }
    }
}
