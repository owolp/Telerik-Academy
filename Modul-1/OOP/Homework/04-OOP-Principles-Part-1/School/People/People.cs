namespace School.People
{
    using Interfaces;

    public class People : ICommentable
    {
        private string firstName;
        private string lastName;
        private string comment;

        public People(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string CommentBox
        {
            get { return this.comment; }
            set { this.comment = value; }
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
    }
}
