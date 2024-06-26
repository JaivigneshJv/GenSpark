﻿using System.Collections;

namespace RequestTrackerApp
{
    internal class Program
    {
        void UnderstaingList()
        {
            ArrayList list = new ArrayList();
            list.Add(100);
            list.Add("Hello");
            list.Add(23.4);
            list.Add(90.3f);
            list.Add(new Employee(101, "Ramu", new DateTime(), "Admin"));
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }

        void UnderstandingGenericList()
        {
            List<int> numbers = new List<int>();
            numbers.Add(100);
            numbers.Add(79);
            numbers.Add(55);
            double total = 0;
            foreach (int i in numbers)
            {
                Console.WriteLine(i);
                total += i;
            }
            Console.WriteLine($"Total is {total}");
        }

        void UnderstandingSet()
        {
            HashSet<string> names = new HashSet<string>()
            {
                "Ramu", "Bimu"
            };
            names.Add("Somu");
            names.Add("Komu");
            names.Add("Timu");
            names.Add("Ramu");
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }

        void UnderstandingDictionary()
        {
            Dictionary<int, string> employees = new Dictionary<int, string>();
            employees.Add(101, "Ramu");
            employees.Add(102, "Komu");
            employees.Add(103, "Bimu");
            employees.Add(104, "Ramu");
            foreach (var key in employees.Keys)
            {
                Console.WriteLine(key + " " + employees[key]);
            }

            if (employees.ContainsKey(101))
            {
                Console.WriteLine("Employee 101 present and name is " + employees[101]);
            }

            if (employees.ContainsValue("Somu"))
            {
                Console.WriteLine("There is an employee with the name Somu in the collection");
            }
        }

        static void Main(string[] args)
        {
            new Program().UnderstandingDictionary();
        }
    }
}
