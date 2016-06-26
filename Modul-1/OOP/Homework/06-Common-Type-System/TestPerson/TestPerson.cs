﻿namespace TestPerson
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Person.Models;

    public class TestPerson
    {
        public static void Main()
        {
            var firstPerson = new Person("Ivan");
            var secondPerson = new Person("Peter", 21);

            Console.WriteLine(new string('=', 50));

            // Problem 4. Person class
            Console.WriteLine("Problem 4. Person class\n");
            Console.WriteLine(firstPerson);
            Console.WriteLine(secondPerson);
        }
    }
}
