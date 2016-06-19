namespace TestStudent
{
    using System;
    using System.Collections.Generic;
    using ExtentionMethods;
    using Student;

    public class TestStudent
    {
        public static void Main()
        {
            var newStudent = new Student("a", "b", 20,  1, "1", "@", 7, new Group(DepartmentName.Mathematics));
            
            List<Student> studentList = new List<Student>();

            studentList.Add(new Student("Lionel", "Holloway", 18, 070706858506, "1-425-133-0955", "sed.dolor.Fusce@acturpis.net", 1, new Group(DepartmentName.Mathematics)));
            studentList[0].AddMarks(new List<double>(new double[] { 2.5, 6.0 }));
            studentList.Add(new Student("Ina", "Collins", 20, 530106621043, "02 301-4750", "elit@pedeac.org", 2, new Group(DepartmentName.Mathematics)));
            studentList[1].AddMarks(new List<double>(new double[] { 3.5, 5.0, 3.5 }));
            studentList.Add(new Student("Basia", "Moran", 29, 275616971406, "511-2466", "Nunc@abv.bg", 2, new Group(DepartmentName.History)));
            studentList[2].AddMarks(new List<double>(new double[] { 4.5, 4.0 }));
            studentList.Add(new Student("Sybil", "Williamson", 23, 765074338205, "288-9785", "gravida@Fuscefermentum.co.uk", 4, new Group(DepartmentName.Biology)));
            studentList[3].AddMarks(new List<double>(new double[] { 5.5, 3.0, 4.5 }));
            studentList.Add(new Student("Alexander", "Madden", 27, 435899618201, "1-369-653-8120", "eu@interdum.ca", 3, new Group(DepartmentName.ComputerScience)));
            studentList[4].AddMarks(new List<double>(new double[] { 6.0, 2.5 }));

            // Problem 3. First before last
            Console.WriteLine("Problem 3. First before last");
            var firstBeforeLastStudents = newStudent.FirstBeforeLastName(studentList);
            foreach (var firstBeforeLastStudent in firstBeforeLastStudents)
            {
                Console.WriteLine("\t{0}, {1}", firstBeforeLastStudent.LastName, firstBeforeLastStudent.FirstName);
            }

            Console.WriteLine(new string('=', 50));

            // Problem 4. Age range
            Console.WriteLine("Problem 4. Age range");
            var ageRangeStudents = newStudent.AgeRange(studentList, 18, 24);
            foreach (var ageRangeStudent in ageRangeStudents)
            {
                Console.WriteLine("\t{0}, {1}", ageRangeStudent.LastName, ageRangeStudent.FirstName);
            }

            Console.WriteLine(new string('=', 50));

            // Problem 5. Order students
            Console.WriteLine("Problem 5. Order students");
            var orderedStudents = newStudent.OrderByFirstAnsLastName(studentList);
            foreach (var orderedStudent in orderedStudents)
            {
                Console.WriteLine("\t{0}, {1}", orderedStudent.LastName, orderedStudent.FirstName);
            }

            Console.WriteLine(new string('=', 50));

            // Problem 9. Student groups
            Console.WriteLine("Problem 9. Student groups");
            var studentsFromGroupTwo = newStudent.FromGroup(studentList, 2);
            var orderedStudentsFromGroupTwo = newStudent.OrderByFirstAnsLastName(studentsFromGroupTwo);
            foreach (var orderedStudentFromGroupTwo in orderedStudentsFromGroupTwo)
            {
                Console.WriteLine("\t{0}, {1}", orderedStudentFromGroupTwo.LastName, orderedStudentFromGroupTwo.FirstName);
            }

            Console.WriteLine(new string('=', 50));

            // Problem 10. Student groups extensions
            Console.WriteLine("Problem 10. Student groups extensions");
            var studentsFromGroupTwoExt = studentList.SortByGroup(2);
            var orderedStudentsFromGroupTwoEx = newStudent.OrderByFirstAnsLastName(studentsFromGroupTwoExt);
            foreach (var orderedStudentFromGroupTwoEx in orderedStudentsFromGroupTwoEx)
            {
                Console.WriteLine("\t{0}, {1}", orderedStudentFromGroupTwoEx.LastName, orderedStudentFromGroupTwoEx.FirstName);
            }

            Console.WriteLine(new string('=', 50));

            // Problem 11. Extract students by email
            Console.WriteLine("Problem 11. Extract students by email");
            var abvEmails = newStudent.ExtractByEmailDomain(studentList, "abv");
            foreach (var abvEmail in abvEmails)
            {
                Console.WriteLine("\t{0}, {1}", abvEmail.LastName, abvEmail.FirstName);
                Console.WriteLine("\t\t{0}", abvEmail.Email);
            }

            Console.WriteLine(new string('=', 50));

            // Problem 12. Extract students by phone
            Console.WriteLine("Problem 12. Extract students by phone");
            var studentsWithSofiaExtention = newStudent.ExtractByPhoneNumber(studentList, "02");
            foreach (var studentWithSofiaExtention in studentsWithSofiaExtention)
            {
                Console.WriteLine("\t{0}, {1}", studentWithSofiaExtention.LastName, studentWithSofiaExtention.FirstName);
                Console.WriteLine("\t\t{0}", studentWithSofiaExtention.PhoneNumber);
            }

            Console.WriteLine(new string('=', 50));

            // Problem 13. Extract students by marks
            Console.WriteLine("Problem 13. Extract students by marks");
            var excellentStudents = newStudent.ExtractByMark(studentList, 6.0);
            foreach (var excellentStudent in excellentStudents)
            {
                Console.WriteLine("\t{0}, {1}", excellentStudent.LastName, excellentStudent.FirstName);
            }

            Console.WriteLine(new string('=', 50));

            // Problem 14. Extract students with two marks
            Console.WriteLine("Problem 14. Extract students with two marks");
            var twoMarksStudents = studentList.ExtactByNumberOfMarks(2);
            foreach (var twoMarksStudent in twoMarksStudents)
            {
                Console.WriteLine("\t{0}, {1}", twoMarksStudent.LastName, twoMarksStudent.FirstName);
            }

            Console.WriteLine(new string('=', 50));

            // Problem 15. Extract marks
            Console.WriteLine("Problem 15. Extract marks");
            var marksOfStudentsFrom2006 = studentList.ExtractMarksByYear(2006);
            foreach (var twoMarksStudent in twoMarksStudents)
            {
                Console.WriteLine("\t{0}, {1}", twoMarksStudent.LastName, twoMarksStudent.FirstName);
                Console.WriteLine("\t\tMarks: {0}", string.Join(", ", twoMarksStudent.Marks));
            }

            Console.WriteLine(new string('=', 50));

            // Problem 16.* Groups
            Console.WriteLine("Problem 16.* Groups");
            var mathematicsDepartmentStudents = newStudent.ExtractByDepartment(studentList, DepartmentName.Mathematics);
            foreach (var mathematicsDepartmentStudent in mathematicsDepartmentStudents)
            {
                Console.WriteLine("\t{0}, {1}", mathematicsDepartmentStudent.LastName, mathematicsDepartmentStudent.FirstName);
                Console.WriteLine("\t\tDepartment: {0}", mathematicsDepartmentStudent.Group.DepartmentName);
            }

            Console.WriteLine(new string('=', 50));

            // Problem 18. Grouped by GroupNumber
            Console.WriteLine("Problem 18. Grouped by GroupNumber");
            var groups = newStudent.GroupByGroupNumber(studentList);
            foreach (var group in groups)
            {
                var isFromGroup = newStudent.FromGroup(studentList, group);

                Console.WriteLine("\tGroup {0}", group);
                foreach (var item in isFromGroup)
                {
                    Console.WriteLine("\t\t{0}, {1}", item.LastName, item.FirstName);
                }
            }

            Console.WriteLine(new string('=', 50));

            // Problem 19. Grouped by GroupName extensions
            Console.WriteLine("Problem 19. Grouped by GroupName extensions");
            var groupsExtentions = studentList.GroupByGroupNumber();
            foreach (var group in groupsExtentions)
            {
                var isFromGroup = newStudent.FromGroup(studentList, group);

                Console.WriteLine("\tGroup {0}", group);
                foreach (var item in isFromGroup)
                {
                    Console.WriteLine("\t\t{0}, {1}", item.LastName, item.FirstName);
                }
            }
        }
    }
}