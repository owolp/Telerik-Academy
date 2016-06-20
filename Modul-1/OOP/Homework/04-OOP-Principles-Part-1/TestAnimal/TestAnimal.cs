namespace TestAnimal
{
    using System;
    using System.Collections.Generic;
    using Animal.AbstractTypes;
    using Animal.Enumerators;
    using Animal.Types;
    using Animal.Types.Felidae;

    public class TestAnimal
    {
        public static void Main()
        {
            var cat = new Cat("Ivan", 2, SexType.Male);
            var dog = new Dog("Dobrin", 1, SexType.Male);
            var kitten = new Kitten("Maria", 3, SexType.Female);
            var tomcat = new Tomcat("Grigor", 5, SexType.Male);
            var frog = new Frog("Penka", 100, SexType.Female);

            var animals = new List<Animal>();
            animals.Add(cat);
            animals.Add(cat);
            animals.Add(dog);
            animals.Add(dog);
            animals.Add(kitten);
            animals.Add(kitten);
            animals.Add(tomcat);
            animals.Add(tomcat);
            animals.Add(frog);
            animals.Add(frog);

            var age = 0.0;

            age = Animal.AverageAge(animals, typeof(Cat));
            Console.WriteLine("The average age of Cat is {0}", age);

            age = Animal.AverageAge(animals, typeof(Dog));
            Console.WriteLine("The average age of Dog is {0}", age);

            age = Animal.AverageAge(animals, typeof(Kitten));
            Console.WriteLine("The average age of Kitten is {0}", age);

            age = Animal.AverageAge(animals, typeof(Tomcat));
            Console.WriteLine("The average age of Tomcat is {0}", age);

            age = Animal.AverageAge(animals, typeof(Frog));
            Console.WriteLine("The average age of Frog is {0}", age);
        }
    }
}