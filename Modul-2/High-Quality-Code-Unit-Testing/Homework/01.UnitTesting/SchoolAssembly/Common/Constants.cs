namespace SchoolAssembly.Common
{
    public class Constants
    {
        // Min and Max Constants
        public const int MinIdNumber = 10000;
        public const int MaxIdNumber = 99999;
        public const int MinStudentsInCourse = 0;
        public const int MaxStudentsInCourse = 30;

        // Strings and Numbers for validation
        public const string StringMustBeBetweenMinAndMax = "{0} must be between {1} and {2} characters long!";
        public const string NumberMustBeBetweenMinAndMax = "{0} must be between {1} and {2}!";

        // String for students, courses
        public const string StudentNameCannotBeNull = "Student name cannot be null!";
        public const string CourseNameCannotBeNull = "Course name cannot be null!";
        public const string SchoolNameCannotBeNull = "School name cannot be null!";
    }
}
