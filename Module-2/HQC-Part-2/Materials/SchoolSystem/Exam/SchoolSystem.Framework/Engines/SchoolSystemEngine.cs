using System;
using System.Collections.Generic;
using System.Linq;

using SchoolSystem.Framework.Engines.Contracts;
using SchoolSystem.Framework.IO.Contracts;
using SchoolSystem.Framework.Models.Contracts;

namespace SchoolSystem.Framework.Engines
{
    public class SchoolSystemEngine : ISchoolSystemEngine
    {
        private readonly IUserInterfaceProvider userInterface;

        private readonly ICommandProvider commandProvider;

        private readonly IDictionary<int, ITeacher> teachers = new Dictionary<int, ITeacher>();

        private readonly IDictionary<int, IStudent> students = new Dictionary<int, IStudent>();

        private int nextStudentId = 0;
        private int nextTeacherId = 0;

        public SchoolSystemEngine(IUserInterfaceProvider userInterface, ICommandProvider commandProvider)
        {
            if (userInterface == null)
            {
                throw new ArgumentNullException(nameof(userInterface));
            }

            if (commandProvider == null)
            {
                throw new ArgumentNullException(nameof(commandProvider));
            }

            this.userInterface = userInterface;
            this.commandProvider = commandProvider;
        }

        public void Start()
        {
            var isRunning = true;
            while (isRunning)
            {
                try
                {
                    var nextInputCommand = this.userInterface.ReadLine();
                    if (nextInputCommand.ToLower().Trim() == "end")
                    {
                        isRunning = false;
                        continue;
                    }

                    if (string.IsNullOrEmpty(nextInputCommand) || string.IsNullOrWhiteSpace(nextInputCommand))
                    {
                        this.userInterface.WriteLine("The passed command is not found!");
                        continue;
                    }

                    var nextInputCommandWords = nextInputCommand.Split(' ');
                    var nextInputCommandName = nextInputCommandWords[0];
                    var commandParameters = nextInputCommandWords.Skip(1).Take(nextInputCommandWords.Length - 1).ToArray();

                    var commandClassInstance = this.commandProvider.FindCommandExecutorWithName(nextInputCommandName);
                    if (commandClassInstance == null)
                    {
                        this.userInterface.WriteLine("The passed command is not found!");
                        continue;
                    }

                    var commandResult = commandClassInstance.Execute(commandParameters, this);

                    this.userInterface.WriteLine(commandResult);
                }
                catch (Exception ex)
                {
                    this.userInterface.WriteLine(ex.Message);
                }
            }
        }

        public int AddStudent(IStudent student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            var id = this.nextStudentId;
            this.nextStudentId++;

            this.students.Add(id, student);

            return id;
        }

        public int AddTeacher(ITeacher teacher)
        {
            if (teacher == null)
            {
                throw new ArgumentNullException(nameof(teacher));
            }

            var id = this.nextTeacherId;
            this.nextTeacherId++;

            this.teachers.Add(id, teacher);

            return id;
        }

        public void RemoveStudent(int id)
        {
            this.students.Remove(id);
        }

        public void RemoveTeacher(int id)
        {
            this.teachers.Remove(id);
        }

        public IStudent GetStudentWithId(int id)
        {
            var student = this.students[id];
            return student;
        }

        public ITeacher GetTeacherWithId(int id)
        {
            var teacher = this.teachers[id];
            return teacher;
        }
    }
}