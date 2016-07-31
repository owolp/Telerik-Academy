namespace School.Common
{
    public class Constants
    {
        // Min and Max Constants
        public const int MinIdNumber = 10000;
        public const int MaxIdNumber = 99999;
        public const int MinStudentsInCourse = 0;
        public const int MaxStudentsInCourse = 30;

        // Strings and Numbers for validation
        public const string NumberMustBeBetweenMinAndMax = "{0} must be between {1} and {2}!";

        // Name validattion
        public const string NameCannotBeNullOrEmpty = "{0} name cannot be null or empty!";
        public const string ObjectCannotBeNullOrEmpty = "{0} cannot be null or empty!";

        // Course validation
        public const string CourseMaxStudentsAdded = "Course cannot have more than 30 students!";

        // Student validation
        public const string StudentNotAttendingCourse = "Student cannot be removed, as he/she is not attending the course!";
        public const string StudentAttendingCourse = "Student already attends the course and cannot be added!";

        // School validation
        public const string StudentNotAttendingSchool = "Student cannot be removed, as he/she is not attending the school!";
        public const string StudentAttendingSchool = "Student already attends the school and cannot be added!";
        public const string CourseAddedToSchool = "Course cannot be removed, as it is not added the school!";
        public const string CourseNotAddedToSchool = "Course is already added the school and cannot be added again!";
    }
}
