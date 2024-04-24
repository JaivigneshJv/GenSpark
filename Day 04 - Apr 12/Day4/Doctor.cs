namespace Day4
{
    class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Experience { get; set; }
        public string Degree { get; set; }
        public string Specialty { get; set; }

        public Doctor(int id, string name, int age, int experience, string degree, string specialty)
        {
            Id = id;
            Name = name;
            Age = age;
            Experience = experience;
            Degree = degree;
            Specialty = specialty;
        }

        public void PrintDoctorDetails()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Experience: {Experience} years");
            Console.WriteLine($"Degree: {Degree}");
            Console.WriteLine($"Specialty: {Specialty}");
            Console.WriteLine();
        }
    }
}

