using ClinicManagementBLLibrary;
using ClinicManagementModelLibrary;

namespace ClinicManagementConsoleApp
{
    class Program
    {
        private readonly IDoctorService _doctorService = new DoctorService();
        private readonly IPatientService _patientService = new PatientService();
        private readonly IAppointmentService _appointmentService = new AppointmentService();

        static void ClearConsole()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.Run();
        }

        private void Run()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("\n--- Clinic Management System ---");
                Console.WriteLine("1. Manage Doctors");
                Console.WriteLine("2. Manage Patients");
                Console.WriteLine("3. Manage Appointments");
                Console.WriteLine("4. Exit");
                Console.Write("\nEnter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        ManageDoctors();
                        break;
                    case 2:
                        ManagePatients();
                        break;
                    case 3:
                        ManageAppointments();
                        break;
                    case 4:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void ManageDoctors()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("\n--- Manage Doctors ---");
                Console.WriteLine("1. Add Doctor");
                Console.WriteLine("2. View All Doctors");
                Console.WriteLine("3. Update Doctor");
                Console.WriteLine("4. Delete Doctor");
                Console.WriteLine("5. Back to Main Menu");
                Console.Write("\nEnter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddDoctor();
                        break;
                    case 2:
                        ViewAllDoctors();
                        break;
                    case 3:
                        UpdateDoctor();
                        break;
                    case 4:
                        DeleteDoctor();
                        break;
                    case 5:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void AddDoctor()
        {
            Console.Write("\nEnter doctor's name: ");
            string? name = Console.ReadLine();

            Console.Write("Enter specialty: ");
            string? specialty = Console.ReadLine();

            Console.Write("Enter contact: ");
            string? contact = Console.ReadLine();

            Console.Write("Enter availability: ");
            if (!int.TryParse(Console.ReadLine(), out int availability))
            {
                Console.WriteLine("Invalid availability. Please enter a valid integer.");
                return;
            }

            Doctor doctor = new Doctor
            (name: name, specialty: specialty, contact: contact, availability: availability);


            int doctorId = _doctorService.AddDoctor(doctor);
            Console.WriteLine($"Doctor added with ID: {doctorId}");
            ClearConsole();
        }

        private void ViewAllDoctors()
        {
            List<Doctor> doctors = _doctorService.GetAllDoctors();
            Console.WriteLine("\n--- All Doctors ---");
            foreach (var doctor in doctors)
            {
                Console.WriteLine($"ID: {doctor.Id}, Name: {doctor.Name}, Specialty: {doctor.Specialty}, Contact: {doctor.Contact}, Availability: {doctor.Availability}");
            }
        }

        private void UpdateDoctor()
        {
            Console.Write("\nEnter doctor ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int doctorId))
            {
                Console.WriteLine("Invalid ID. Please enter a valid integer.");
                return;
            }

            Doctor existingDoctor = _doctorService.GetDoctorById(doctorId);
            if (existingDoctor == null)
            {
                Console.WriteLine("Doctor not found.");
                return;
            }

            Console.Write("Enter new name (leave blank to keep current): ");
            string? name = Console.ReadLine();

            Console.Write("Enter new specialty (leave blank to keep current): ");
            string? specialty = Console.ReadLine();

            Console.Write("Enter new contact (leave blank to keep current): ");
            string? contact = Console.ReadLine();

            Console.Write("Enter new availability (leave blank to keep current): ");
            if (int.TryParse(Console.ReadLine(), out int availability))
            {
                existingDoctor.Availability = availability;
            }

            if (!string.IsNullOrEmpty(name))
            {
                existingDoctor.Name = name;
            }

            if (!string.IsNullOrEmpty(specialty))
            {
                existingDoctor.Specialty = specialty;
            }

            if (!string.IsNullOrEmpty(contact))
            {
                existingDoctor.Contact = contact;
            }

            Doctor updatedDoctor = _doctorService.UpdateDoctor(existingDoctor);
            if (updatedDoctor != null)
            {
                Console.WriteLine("Doctor updated successfully.");
            }
            else
            {
                Console.WriteLine("Failed to update doctor.");
            }
            ClearConsole();

        }

        private void DeleteDoctor()
        {
            Console.Write("\nEnter doctor ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int doctorId))
            {
                Console.WriteLine("Invalid ID. Please enter a valid integer.");
                return;
            }

            Doctor deletedDoctor = _doctorService.DeleteDoctor(doctorId);
            if (deletedDoctor != null)
            {
                Console.WriteLine($"Doctor with ID {doctorId} deleted successfully.");
            }
            else
            {
                Console.WriteLine($"Failed to delete doctor with ID {doctorId}.");
            }
            ClearConsole();

        }

        private void ManagePatients()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("\n--- Manage Patients ---");
                Console.WriteLine("1. Add Patient");
                Console.WriteLine("2. View All Patients");
                Console.WriteLine("3. Update Patient");
                Console.WriteLine("4. Delete Patient");
                Console.WriteLine("5. Back to Main Menu");
                Console.Write("\nEnter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddPatient();
                        break;
                    case 2:
                        ViewAllPatients();
                        break;
                    case 3:
                        UpdatePatient();
                        break;
                    case 4:
                        DeletePatient();
                        break;
                    case 5:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void AddPatient()
        {
            Console.Write("\nEnter patient's name: ");
            string? name = Console.ReadLine();

            Console.Write("Enter date of birth (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime dob))
            {
                Console.WriteLine("Invalid date. Please enter a date in the format yyyy-MM-dd.");
                return;
            }

            Console.Write("Enter contact: ");
            string? contact = Console.ReadLine();

            Console.Write("Enter address: ");
            string? address = Console.ReadLine();

            Patient patient = new Patient(name: name, dateOfBirth: dob, contact: contact, address: address);


            int patientId = _patientService.AddPatient(patient);
            Console.WriteLine($"Patient added with ID: {patientId}");

            ClearConsole();

        }

        private void ViewAllPatients()
        {
            List<Patient> patients = _patientService.GetAllPatients();
            Console.WriteLine("\n--- All Patients ---");
            foreach (var patient in patients)
            {
                Console.WriteLine($"ID: {patient.Id}, Name: {patient.Name}, Date of Birth: {patient.DateOfBirth:yyyy-MM-dd}, Contact: {patient.Contact}, Address: {patient.Address}");
            }
            ClearConsole();

        }

        private void UpdatePatient()
        {
            Console.Write("\nEnter patient ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int patientId))
            {
                Console.WriteLine("Invalid ID. Please enter a valid integer.");
                return;
            }

            Patient existingPatient = _patientService.GetPatientById(patientId);
            if (existingPatient == null)
            {
                Console.WriteLine("Patient not found.");
                return;
            }

            Console.Write("Enter new name (leave blank to keep current): ");
            string? name = Console.ReadLine();

            Console.Write("Enter new date of birth (leave blank to keep current, yyyy-MM-dd): ");
            string? dobInput = Console.ReadLine();

            if (DateTime.TryParse(dobInput, out DateTime dob))
            {
                existingPatient.DateOfBirth = dob;
            }

            Console.Write("Enter new contact (leave blank to keep current): ");
            string? contact = Console.ReadLine();

            Console.Write("Enter new address (leave blank to keep current): ");
            string? address = Console.ReadLine();

            if (!string.IsNullOrEmpty(name))
            {
                existingPatient.Name = name;
            }

            if (!string.IsNullOrEmpty(contact))
            {
                existingPatient.Contact = contact;
            }

            if (!string.IsNullOrEmpty(address))
            {
                existingPatient.Address = address;
            }

            Patient updatedPatient = _patientService.UpdatePatient(existingPatient);
            if (updatedPatient != null)
            {
                Console.WriteLine("Patient updated successfully.");
            }
            else
            {
                Console.WriteLine("Failed to update patient.");
            }
            ClearConsole();

        }

        private void DeletePatient()
        {
            Console.Write("\nEnter patient ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int patientId))
            {
                Console.WriteLine("Invalid ID. Please enter a valid integer.");
                return;
            }

            Patient deletedPatient = _patientService.DeletePatient(patientId);
            if (deletedPatient != null)
            {
                Console.WriteLine($"Patient with ID {patientId} deleted successfully.");
            }
            else
            {
                Console.WriteLine($"Failed to delete patient with ID {patientId}.");
            }

            ClearConsole();

        }

        private void ManageAppointments()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("\n--- Manage Appointments ---");
                Console.WriteLine("1. Add Appointment");
                Console.WriteLine("2. View All Appointments");
                Console.WriteLine("3. Update Appointment");
                Console.WriteLine("4. Delete Appointment");
                Console.WriteLine("5. Back to Main Menu");
                Console.Write("\nEnter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddAppointment();
                        break;
                    case 2:
                        ViewAllAppointments();
                        break;
                    case 3:
                        UpdateAppointment();
                        break;
                    case 4:
                        DeleteAppointment();
                        break;
                    case 5:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void AddAppointment()
        {
            Console.Write("\nEnter patient ID: ");
            if (!int.TryParse(Console.ReadLine(), out int patientId))
            {
                Console.WriteLine("Invalid ID. Please enter a valid integer.");
                return;
            }

            Console.Write("Enter doctor ID: ");
            if (!int.TryParse(Console.ReadLine(), out int doctorId))
            {
                Console.WriteLine("Invalid ID. Please enter a valid integer.");
                return;
            }

            Console.Write("Enter appointment date and time (yyyy-MM-dd HH:mm): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime appointmentDateTime))
            {
                Console.WriteLine("Invalid date and time. Please enter a date and time in the format yyyy-MM-dd HH:mm.");
                return;
            }

            Appointment appointment = new Appointment(doctorId, patientId, appointmentDateTime, status: string.Empty);

            int appointmentId = _appointmentService.AddAppointment(appointment);
            Console.WriteLine($"Appointment added with ID: {appointmentId}");

            ClearConsole();

        }

        private void ViewAllAppointments()
        {
            List<Appointment> appointments = _appointmentService.GetAllAppointments();
            Console.WriteLine("\n--- All Appointments ---");
            foreach (var appointment in appointments)
            {
                Console.WriteLine($"ID: {appointment.Id}, Patient ID: {appointment.PatientId}, Doctor ID: {appointment.DoctorId}, Appointment DateTime: {appointment.DateTime}");
            }

            ClearConsole();

        }

        private void UpdateAppointment()
        {
            Console.Write("\nEnter appointment ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int appointmentId))
            {
                Console.WriteLine("Invalid ID. Please enter a valid integer.");
                return;
            }

            Appointment existingAppointment = _appointmentService.GetAppointmentById(appointmentId);
            if (existingAppointment == null)
            {
                Console.WriteLine("Appointment not found.");
                return;
            }

            Console.Write("Enter new patient ID (leave blank to keep current): ");
            string? patientIdInput = Console.ReadLine();
            if (int.TryParse(patientIdInput, out int patientId))
            {
                existingAppointment.PatientId = patientId;
            }

            Console.Write("Enter new doctor ID (leave blank to keep current): ");
            string? doctorIdInput = Console.ReadLine();
            if (int.TryParse(doctorIdInput, out int doctorId))
            {
                existingAppointment.DoctorId = doctorId;
            }

            Console.Write("Enter new appointment date and time (leave blank to keep current, yyyy-MM-dd HH:mm): ");
            string? appointmentDateTimeInput = Console.ReadLine();
            if (DateTime.TryParse(appointmentDateTimeInput, out DateTime appointmentDateTime))
            {
                existingAppointment.DateTime = appointmentDateTime;
            }

            Appointment updatedAppointment = _appointmentService.UpdateAppointment(existingAppointment);
            if (updatedAppointment != null)
            {
                Console.WriteLine("Appointment updated successfully.");
            }
            else
            {
                Console.WriteLine("Failed to update appointment.");
            }

            ClearConsole();

        }

        private void DeleteAppointment()
        {
            Console.Write("\nEnter appointment ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int appointmentId))
            {
                Console.WriteLine("Invalid ID. Please enter a valid integer.");
                return;
            }

            Appointment deletedAppointment = _appointmentService.DeleteAppointment(appointmentId);
            if (deletedAppointment != null)
            {
                Console.WriteLine($"Appointment with ID {appointmentId} deleted successfully.");
            }
            else
            {
                Console.WriteLine($"Failed to delete appointment with ID {appointmentId}.");
            }
            ClearConsole();

        }
    }
}
