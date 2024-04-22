using HotelBookingSystemBLLibrary;
using HotelBookingSystemDALLibrary;
using HotelBookingSystemModelLibrary;

namespace HotelBookingSystem
{
    class Program
    {
        static IRoomInventoryService? roomService;
        static IReservationService? reservationService;
        static IGuestService? guestService;
        static ILoginService? loginService;

        public static void ClearConsole()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Hotel Booking System!");
            roomService = new RoomInventoryBL(new RoomInventoryRepository());
            reservationService = new ReservationBL(new ReservationRepository());
            guestService = new GuestBL(new GuestRepository());
            loginService = new LoginBL(new LoginRepository());

            while (true)
            {
                LoginMenu();
                string? input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Login();
                        break;
                    case "2":
                        Register();
                        break;
                    case "3":
                        Console.WriteLine("Exiting the program.");

                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        ClearConsole();
                        break;
                }
            }
        }

        static void LoginMenu()
        {
            Console.WriteLine("\nLogin Menu:");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            Console.WriteLine("3. Exit");
            Console.WriteLine("Choose an option:");
        }
        static void Login()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Enter your username:");
                string? username = Console.ReadLine();

                Console.WriteLine("Enter your password:");
                string? password = Console.ReadLine();

                var user = loginService?.GetByUsername(username!);

                if (user != null && user.Password == password)
                {
                    Console.WriteLine($"Welcome, {username}!");
                    ClearConsole();
                    //ENUM MANIPULATION
                    if(user.UserType==UserType.Guest)
                    {
                        ShowMainMenu();
                    }
                    else if (user.UserType == UserType.RoomOwner)
                    {
                        ShowMainMenu();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid username or password.");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error! Try Again");
            }
        }

        static void Register()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Enter your username:");
                string? username = Console.ReadLine();

                Console.WriteLine("Enter your password:");
                string? password = Console.ReadLine();

                Console.WriteLine("Choose your user type (1 for Guest, 2 for RoomOwner):");
                UserType userType;
                if (Enum.TryParse(Console.ReadLine(), out userType))
                {
                    var newUser = new Login { Username = username, Password = password, UserType = userType };
                    loginService?.AddLogin(newUser);

                    Console.WriteLine("Registration successful. You can now login.");
                    ClearConsole();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error! Try Again");
            }
        }

        static void ShowMainMenu()
        {
            while (true)
            {
                MainMenu();
                string? input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        RoomManagement();
                        break;
                    case "2":
                        ReservationManagement();
                        break;
                    case "3":
                        GuestManagement();
                        break;
                    case "4":
                        Console.WriteLine("Exiting to Login Page!.");
                        ClearConsole();
                        return;
                    default:
                        ClearConsole();
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("\nMain Menu:");
            Console.WriteLine("1. Room Management");
            Console.WriteLine("2. Reservation Management");
            Console.WriteLine("3. Guest Management");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Choose an option:");
        }

        static void RoomManagementMenu()
        {
            Console.Clear();
            Console.WriteLine("\nRoom Management Menu:");
            Console.WriteLine("1. View All Rooms");
            Console.WriteLine("2. Add New Room");
            Console.WriteLine("3. Update Room");
            Console.WriteLine("4. Delete Room");
            Console.WriteLine("5. Back to Main Menu");
            Console.WriteLine("Choose an option:");
        }

        static void ReservationManagementMenu()
        {
            Console.Clear();
            Console.WriteLine("\nReservation Management Menu:");
            Console.WriteLine("1. View All Reservations");
            Console.WriteLine("2. Add New Reservation");
            Console.WriteLine("3. Update Reservation");
            Console.WriteLine("4. Cancel Reservation");
            Console.WriteLine("5. Back to Main Menu");
            Console.WriteLine("Choose an option:");
        }

        static void GuestManagementMenu()
        {
            Console.Clear();
            Console.WriteLine("\nGuest Management Menu:");
            Console.WriteLine("1. View All Guests");
            Console.WriteLine("2. Add New Guest");
            Console.WriteLine("3. Update Guest");
            Console.WriteLine("4. Delete Guest");
            Console.WriteLine("5. Back to Main Menu");
            Console.WriteLine("Choose an option:");
        }

        static void RoomManagement()
        {
            while (true)
            {
                RoomManagementMenu();
                string? input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ViewAllRooms();
                        break;
                    case "2":
                        AddNewRoom();
                        break;
                    case "3":
                        UpdateRoom();
                        break;
                    case "4":
                        DeleteRoom();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        ClearConsole();
                        break;
                }
            }
        }

        static void ReservationManagement()
        {
            while (true)
            {
                ReservationManagementMenu();
                string? input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ViewAllReservations();
                        break;
                    case "2":
                        AddNewReservation();
                        break;
                    case "3":
                        UpdateReservation();
                        break;
                    case "4":
                        CancelReservation();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        ClearConsole();
                        break;
                }
            }
        }

        static void GuestManagement()
        {
            while (true)
            {
                GuestManagementMenu();
                string? input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ViewAllGuests();
                        break;
                    case "2":
                        AddNewGuest();
                        break;
                    case "3":
                        UpdateGuest();
                        break;
                    case "4":
                        DeleteGuest();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        ClearConsole();
                        break;
                }
            }
        }

        static void ViewAllRooms()
        {
            Console.Clear();
            var rooms = roomService?.GetAllRooms();
            if (rooms != null && rooms.Any())
            {
                foreach (var room in rooms)
                {
                    Console.WriteLine($"Room ID: {room.Id}, Name: {room.Name}, Type: {room.Type}, Features: {room.Features}, Nightly Rate: {room.NightlyRate}, Occupancy Capacity: {room.OccupancyCapacity}");
                }
            }
            else
            {
                Console.WriteLine("No rooms found.");
            }
            ClearConsole();

        }

        static void AddNewRoom()
        {
            Console.Clear();

            Console.WriteLine("Enter room name:");
            string name = Console.ReadLine() ?? "";

            Console.WriteLine("Enter room type:");
            string type = Console.ReadLine() ?? "";

            Console.WriteLine("Enter room features:");
            string features = Console.ReadLine() ?? "";

            Console.WriteLine("Enter nightly rate:");
            decimal nightlyRate = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Enter occupancy capacity:");
            int occupancyCapacity = Convert.ToInt32(Console.ReadLine());

            var room = new Room(0, name, type, features, occupancyCapacity, nightlyRate);
            roomService?.AddRoom(room);
            ClearConsole();

        }

        static void UpdateRoom()
        {
            Console.Clear();

            Console.WriteLine("Enter the ID of the room you want to update:");
            int id = Convert.ToInt32(Console.ReadLine());

            var room = roomService?.GetRoomById(id);
            if (room != null)
            {
                Console.WriteLine("Enter updated room name:");
                room.Name = Console.ReadLine() ?? "";

                Console.WriteLine("Enter updated room type:");
                room.Type = Console.ReadLine() ?? "";

                Console.WriteLine("Enter updated room features:");
                room.Features = Console.ReadLine() ?? "";

                Console.WriteLine("Enter updated nightly rate:");
                room.NightlyRate = Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine("Enter updated occupancy capacity:");
                room.OccupancyCapacity = Convert.ToInt32(Console.ReadLine());

                roomService?.UpdateRoom(room);
                Console.WriteLine("Room updated successfully.");
            }
            else
            {
                Console.WriteLine("Room not found.");
            }
            ClearConsole();

        }

        static void DeleteRoom()
        {
            Console.Clear();

            Console.WriteLine("Enter the ID of the room you want to delete:");
            int id = Convert.ToInt32(Console.ReadLine());

            var room = roomService?.GetRoomById(id);
            if (room != null)
            {
                roomService?.DeleteRoom(id);
                Console.WriteLine("Room deleted successfully.");
            }
            else
            {
                Console.WriteLine("Room not found.");
            }
            ClearConsole();

        }

        static void ViewAllReservations()
        {
            Console.Clear();

            var reservations = reservationService?.GetAllReservations();
            if (reservations != null && reservations.Any())
            {
                foreach (var reservation in reservations)
                {
                    Console.WriteLine($"Reservation ID: {reservation.Id}, Room ID: {reservation.RoomId}, Guest ID: {reservation.GuestId}, Start Date: {reservation.CheckInDate}, End Date: {reservation.CheckOutDate}");
                }
            }
            else
            {
                Console.WriteLine("No reservations found.");
            }
            ClearConsole();

        }

        static void AddNewReservation()
        {
            Console.Clear();

            Console.WriteLine("Enter room ID:");
            int roomId = Convert.ToInt32(Console.ReadLine());
            var room = roomService?.GetRoomById(roomId);
            if (room == null)
            {
                Console.WriteLine("Room not found.");
                return;
            }

            Console.WriteLine("Enter guest ID:");
            int guestId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter start date (yyyy-MM-dd):");
            DateTime startDate = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Enter end date (yyyy-MM-dd):");
            DateTime endDate = Convert.ToDateTime(Console.ReadLine());

            var reservation = new Reservation(0, roomId, guestId, startDate, endDate, room.NightlyRate, "true");
            reservationService?.AddReservation(reservation);
            ClearConsole();
        }

        static void UpdateReservation()
        {
            Console.Clear();

            Console.WriteLine("Enter the ID of the reservation you want to update:");
            int id = Convert.ToInt32(Console.ReadLine());

            var reservation = reservationService?.GetReservationById(id);
            if (reservation != null)
            {
                Console.WriteLine("Enter updated room ID:");
                reservation.RoomId = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter updated guest ID:");
                reservation.GuestId = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter updated start date (yyyy-MM-dd):");
                reservation.CheckInDate = Convert.ToDateTime(Console.ReadLine());

                Console.WriteLine("Enter updated end date (yyyy-MM-dd):");
                reservation.CheckOutDate = Convert.ToDateTime(Console.ReadLine());

                reservationService?.UpdateReservation(reservation);
                Console.WriteLine("Reservation updated successfully.");
            }
            else
            {
                Console.WriteLine("Reservation not found.");
            }
            ClearConsole();
        }

        static void CancelReservation()
        {
            Console.Clear();

            Console.WriteLine("Enter the ID of the reservation you want to cancel:");
            int id = Convert.ToInt32(Console.ReadLine());

            var reservation = reservationService?.GetReservationById(id);
            if (reservation != null)
            {
                reservationService?.CancelReservation(id);
                Console.WriteLine("Reservation canceled successfully.");
            }
            else
            {
                Console.WriteLine("Reservation not found.");
            }
            ClearConsole();
        }

        static void ViewAllGuests()
        {
            Console.Clear();

            var guests = guestService?.GetAllGuests();
            if (guests != null && guests.Any())
            {
                foreach (var guest in guests)
                {
                    Console.WriteLine($"Guest ID: {guest.Id}, Name: {guest.Name}, Email: {guest.Email}, Phone: {guest.Contact}");
                }
            }
            else
            {
                Console.WriteLine("No guests found.");
            }
            ClearConsole();
        }

        static void AddNewGuest()
        {
            Console.Clear();

            Console.WriteLine("Enter guest name:");
            string name = Console.ReadLine() ?? "";

            Console.WriteLine("Enter guest email:");
            string email = Console.ReadLine() ?? "";

            Console.WriteLine("Enter guest phone:");
            string phone = Console.ReadLine() ?? "";

            var guest = new Guest(0, name, email, phone);
            guestService?.AddGuest(guest);
            ClearConsole();
        }

        static void UpdateGuest()
        {
            Console.Clear();

            Console.WriteLine("Enter the ID of the guest you want to update:");
            int id = Convert.ToInt32(Console.ReadLine());

            var guest = guestService?.GetGuestById(id);
            if (guest != null)
            {
                Console.WriteLine("Enter updated guest name:");
                guest.Name = Console.ReadLine() ?? "";

                Console.WriteLine("Enter updated guest email:");
                guest.Email = Console.ReadLine() ?? "";

                Console.WriteLine("Enter updated guest phone:");
                guest.Contact = Console.ReadLine() ?? "";

                guestService?.UpdateGuest(guest);
                Console.WriteLine("Guest updated successfully.");
            }
            else
            {
                Console.WriteLine("Guest not found.");
            }
            ClearConsole();
        }

        static void DeleteGuest()
        {
            Console.Clear();

            Console.WriteLine("Enter the ID of the guest you want to delete:");
            int id = Convert.ToInt32(Console.ReadLine());

            var guest = guestService?.GetGuestById(id);
            if (guest != null)
            {
                guestService?.DeleteGuest(id);
                Console.WriteLine("Guest deleted successfully.");
            }
            else
            {
                Console.WriteLine("Guest not found.");
            }
            ClearConsole();
        }
    }
}
