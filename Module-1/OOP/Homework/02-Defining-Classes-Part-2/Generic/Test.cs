namespace Generic
{
    using System;

    public class Test
    {
        // Problem 5. Generic class
        // Keep the elements of the List in an array with fixed capacity which is given as parameter in the class constructor.
        private static GenericList<int> list = new GenericList<int>(6);

        public static GenericList<int> List
        {
            get { return list; }
            set { list = value; }
        }

        public static void Main()
        {
            // Method for adding element
            List.AddElement(10);
            List.AddElement(20);
            List.AddElement(30);
            List.AddElement(40);
            List.AddElement(50);
            List.AddElement(60);
            List.AddElement(70);
            List.AddElement(80);
            List.AddElement(90);
            List.AddElement(100);
            Console.WriteLine("Method for adding element:");
            Console.WriteLine("\t {0}", List);

            // Method for accessing element by index
            List.InsertByIndex(1, 1000);
            List.InsertByIndex(5, 2000);
            Console.WriteLine("Method for accessing element by index:");
            Console.WriteLine("\t {0}", List);

            // Method for removing element by index
            List.RemoveByIndex(2);
            List.RemoveByIndex(4);
            Console.WriteLine("Method for removing element by index:");
            Console.WriteLine("\t {0}", List);

            // Method for inserting element at given position
            List.InsertByIndex(1, 250);
            List.InsertByIndex(6, 1250);
            Console.WriteLine("Method for inserting element at given position:");
            Console.WriteLine("\t {0}", List);

            // Method for finding element by its value
            List.FindElement(30);
            Console.WriteLine("Method for finding element by its value:");
            Console.WriteLine("\t {0}", List);

            // Problem 7. Min and Max
            Console.WriteLine("Method for finding min element:");
            Console.WriteLine("\t {0}", List.Min());
            Console.WriteLine("Method for finding max element:");
            Console.WriteLine("\t {0}", List.Max());

            // Method for clearing the List
            List.ClearData();
            Console.WriteLine("Method for clearing the List:");
            Console.WriteLine("\t {0}", List);
        }
    }
}
