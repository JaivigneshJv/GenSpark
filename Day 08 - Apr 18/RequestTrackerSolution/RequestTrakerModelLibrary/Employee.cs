using System;

namespace RequestTrackerModelLibrary
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Salary { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age => (int)Math.Floor((DateTime.Now - DateOfBirth).TotalDays / 365.25);
        public string? Role { get; set; }
        public string? Type { get; set; }
        public Department? EmployeeDepartment { get; set; }

        public override string ToString()
        {
            return $"{Id}: {Name ?? "Unnamed Employee"} - Age: {Age}, Salary: {Salary}, Role: {Role}, Type: {Type}";
        }

        public override bool Equals(object? obj)
        {
            if (obj is Employee employee)
            {
                return Id == employee.Id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}
