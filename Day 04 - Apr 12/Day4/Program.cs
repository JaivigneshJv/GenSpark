namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            Doctor[] doctors = new Doctor[]
            {
                        new Doctor(1, "Dr. Smith", 45, 20, "MD", "Cardiology"),
                        new Doctor(2, "Dr. Jones", 50, 25, "PhD", "Neurology"),
                        new Doctor(3, "Dr. Patel", 40, 15, "MBBS", "Pediatrics"),
                        new Doctor(4, "Dr. Smith2", 45, 20, "MD", "Cardiology"),
                        new Doctor(5, "Dr. Jones2", 50, 25, "PhD", "Neurology"),
                        new Doctor(6, "Dr. Patel2", 40, 15, "MBBS", "Pediatrics")
            };

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. View all doctors");
                Console.WriteLine("2. Search doctors by specialty");
                Console.WriteLine("3. Add new doctor");
                Console.WriteLine("4. Number Manipulation");

                Console.WriteLine("5. Exit");

                Console.Write("Enter your choice: ");
                string? choice = Console.ReadLine();

                Console.Clear();

                switch (choice)
                {
                    case "1":
                        ViewAllDoctors(doctors);
                        break;
                    case "2":
                        SearchDoctorsBySpecialty(doctors);
                        break;
                    case "3":
                        AddNewDoctor(ref doctors);
                        break;
                    case "4":
                        Numbermani.NumberManipulation();
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void ViewAllDoctors(Doctor[] doctors)
        {
            Console.WriteLine("All Doctors:");
            foreach (var doctor in doctors)
            {
                doctor.PrintDoctorDetails();
            }
        }

        static void SearchDoctorsBySpecialty(Doctor[] doctors)
        {
            Console.WriteLine("Enter a specialty to search for doctors:");
            string? searchSpecialty = Console.ReadLine();

            Console.WriteLine($"Doctors with specialty {searchSpecialty}:");
            foreach (var doctor in doctors)
            {
                if (doctor.Specialty.Equals(searchSpecialty, StringComparison.OrdinalIgnoreCase))
                {
                    doctor.PrintDoctorDetails();
                }
            }
        }

        static void AddNewDoctor(ref Doctor[] doctors)
        {
            Console.WriteLine("Enter the details of the new doctor:");
            Console.Write("ID: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid input. Please enter a valid ID:");
            }

            Console.Write("Name: ");
            string? name = Console.ReadLine();

            Console.Write("Age: ");
            int age;
            while (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("Invalid input. Please enter a valid age:");
            }

            Console.Write("Experience: ");
            int experience;
            while (!int.TryParse(Console.ReadLine(), out experience))
            {
                Console.WriteLine("Invalid input. Please enter a valid experience:");
            }

            Console.Write("Degree: ");
            string? degree = Console.ReadLine();

            Console.Write("Specialty: ");
            string? specialty = Console.ReadLine();

            Doctor newDoctor = new Doctor(id, name!, age, experience, degree!, specialty!);
            Array.Resize(ref doctors, doctors.Length + 1);
            doctors[doctors.Length - 1] = newDoctor;

            Console.WriteLine("New doctor added successfully!");
        }
    }
}
