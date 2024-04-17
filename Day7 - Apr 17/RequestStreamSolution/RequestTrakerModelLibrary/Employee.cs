﻿using System;

namespace RequestTrakerModelLibrary
{
    public class Employee
    {
        public Department EmployeeDepartment { get; set; }
        private int age;
        private DateTime dob;

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public int Age
        {
            get { return age; }
        }

        public DateTime DateOfBirth
        {
            get => dob;
            set
            {
                dob = value;
                age = ((DateTime.Today - dob).Days) / 365;
            }
        }

        public double Salary { get; set; }
        public string Type { get; set; }
        public string Role { get; set; }

        public Employee()
        {
            Id = 0;
            Name = string.Empty;
            Salary = 0.0;
            DateOfBirth = new DateTime();
            Type = string.Empty;
            Role = "Employee";
        }

        public Employee(int id, string name, DateTime dateOfBirth, string role)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            Role = role;
        }

        public virtual void BuildEmployeeFromConsole()
        {
            Console.WriteLine("Please enter the Name");
            Name = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Please enter the Date of birth");
            DateOfBirth = Convert.ToDateTime(Console.ReadLine());
            Role = "Employee";
        }

        public override string ToString()
        {
            return $"Employee Type: {Type}\nEmployee Id: {Id}\nEmployee Name: {Name}\nDate of birth: {DateOfBirth}\nEmployee Age: {Age}\nEmployee Role: {Role}";
        }

        public override bool Equals(object? obj)
        {
            Employee? e2 = obj as Employee;
            return e2 != null && this.Id == e2.Id;
        }

        public static bool operator ==(Employee e1, Employee e2)
        {
            return e1.Id == e2.Id;
        }

        public static bool operator !=(Employee e1, Employee e2)
        {
            return e1.Id != e2.Id;
        }
    }
}
