using System;
using System.Collections.Generic;

namespace SampleProgram
{
    // Enum
    public enum Days { Sun, Mon, Tue, Wed, Thu, Fri, Sat };

    // Structure
    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    // Record
    public record Person(string Name, int Age);

    // Abstract Class
    public abstract class Shape
    {
        public abstract double Area();
    }

    public class Circle : Shape
    {
        public double Radius { get; set; }

        // Function Overriding
        public override double Area()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }

    // Class
    public class Calculator
    {
        // Function Overloading
        public int Add(int a, int b)
        {
            return a + b;
        }

        public double Add(double a, double b)
        {
            return a + b;
        }
    }

    // Custom Exception
    public class CustomException : Exception
    {
        public CustomException(string message) : base(message) { }
    }

    class Program
    {
        // Indexers
        private string[] array = new string[10];

        public string this[int i]
        {
            get { return array[i]; }
            set { array[i] = value; }
        }

        // Jagged Array
        int[][] jaggedArray = new int[][]
        {
            new int[] {1,2,3},
            new int[] {4,5},
            new int[] {6,7,8,9}
        };

        static void Main(string[] args)
        {
            try
            {
                // Polymorphism
                Shape shape = new Circle { Radius = 5 };
                Console.WriteLine($"Area of Circle: {shape.Area()}");

                // Function Overloading
                Calculator calculator = new Calculator();
                Console.WriteLine($"Add Int: {calculator.Add(1, 2)}");
                Console.WriteLine($"Add Double: {calculator.Add(1.5, 2.5)}");

                // Enum
                Console.WriteLine($"Day: {Days.Mon}");

                // Structure
                Point point = new Point { X = 10, Y = 20 };
                Console.WriteLine($"Point: {point.X}, {point.Y}");

                // Record
                Person person = new Person("John", 25);
                Console.WriteLine($"Person: {person.Name}, {person.Age}");

                // Custom Exception
                throw new CustomException("This is a custom exception.");
            }
            catch (CustomException ex)
            {
                Console.WriteLine($"Caught an exception: {ex.Message}");
            }
        }
    }
}