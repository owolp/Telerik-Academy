namespace Initial
{
    using System;
    using TestAnimal;
    using TestSchool;
    using TestStudentsAndWorkers;

    public class Initial
    {
        public static void Main()
        {
            Action initialMethod = TestSchool.Main;
            initialMethod += TestStudentsAndWorkers.Main;
            initialMethod += TestAnimal.Main;

            initialMethod();
        }
    }
}
