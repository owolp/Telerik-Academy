﻿//10. Fibonacci Numbers
//Description
//Write a program that reads a number N and prints on the console the first N members of the Fibonacci sequence(at a single line, separated by comma and space - ", "):
//0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, ….
//Input
//    On the only line you will receive the number N
//Output
//    On the only line you should print the first N numbers of the sequence, separated by ", " (comma and space)
//Constraints
//    1 <= N <= 50
//    N will always be a valid positive integer number
//    Time limit: 0.1s
//    Memory limit: 8MB

using System;

class Program
{
    static void Main()
    {
        int quantity = int.Parse(Console.ReadLine());
        for (int i = 0; i < quantity; i++)
        {
            Console.WriteLine(Fibonacci(i));
        }
    }

    public static double Fibonacci(int n)
    {
        double a = 0;
        double b = 1;

        for (int i = 0; i < n; i++)
        {
            double temp = a;
            a = b;
            b = temp + b;
        }
        return a;
    }
}