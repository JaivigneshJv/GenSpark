# Hotel Booking System

## Objective
Develop a console-based hotel booking system to enable guests to book rooms, manage reservations, and access hotel services easily.

## Implementation

The system is divided into four layers:

1. **Model Library (HotelBookingSystemModelLibrary)**: This layer contains the data models for `Room`, `Reservation`, and `Guest`.

2. **Data Access Layer (HotelBookingSystemDALLibrary)**: This layer contains repositories for all the entities. It interacts with the database and performs CRUD operations.

3. **Business Logic Layer (HotelBookingSystemBLLibrary)**: This layer contains the business logic of the application. It interacts with the DAL and transforms data to and from the Models.

4. **Console Application (HotelBookingSystem)**: This is the entry point of the application. It interacts with the BLL and presents data to the user.

The system also demonstrates various programming concepts like polymorphism, function overloading, function overriding, class, structure, enum, records, abstract class, indexers, jagged array, exception handling, and custom exception.

## Functional Requirements

### Room Inventory Management
Maintain a comprehensive inventory of available rooms, including details such as room type (e.g., single, double, suite), features (e.g., air conditioning, Wi-Fi, ocean view), occupancy capacity, and nightly rate.

### Reservation Processing
Enable guests to search for available rooms based on their desired check-in and check-out dates, room type, and occupancy needs. Allow guests to book rooms, providing personal details, specific preference. Generate reservation confirmations that include reservation details, total cost, and cancellation policies.

### Guest Management
Maintain records of guests including contact details, reservation history, and preferences. Implement functionality for guests to view their reservation details, modify bookings, or cancel reservations.


## Getting Started

To run this application, ensure you have .NET 6 installed on your machine. 

1. Open a terminal.
2. Navigate to the project directory using `cd Day8\ -\ Apr\ 18/RequestTrackerSolution/`.
3. Run the program using the command `dotnet run`.



<br><br><br><br><br><br><br><br><br><br><br><br><br><br>

## Hotel Booking System

### Objective:
Develop a console-based hotel booking system to enable guests to book rooms, manage reservations, and access hotel services easily.

#### Functional Requirements:

1. **Room Inventory Management:**
   - Maintain a comprehensive inventory of available rooms, including details such as room type (e.g., single, double, suite), features (e.g., air conditioning, Wi-Fi, ocean view), occupancy capacity, and nightly rate.

2. **Reservation Processing:**
   - Enable guests to search for available rooms based on their desired check-in and check-out dates, room type, and occupancy needs.
   - Allow guests to book rooms, providing personal details, specific preference
   - Generate reservation confirmations that include reservation details, total cost, and cancellation policies.

3. **Guest Management:**
   - Maintain records of guests including contact details, reservation history, and preferences.
   - Implement functionality for guests to view their reservation details, modify bookings, or cancel reservations.


#### Non-Functional Requirements:

1. **User Interface:**
   - Design an intuitive console interface with clear navigation and prompts to ensure ease of use for both guests and hotel staff.

2. **Efficiency:**
   - Ensure that the system processes bookings and updates quickly and accurately, especially during peak booking periods.

3. **Reliability:**
   - The system should be highly reliable, maintaining continuous operation and preserving data integrity.

4. **Security:**
   - Implement strong security measures to protect guest data and financial transactions from unauthorized access.

5. **Scalability:**
   - Design the system to easily accommodate growth in hotel size, number of bookings, and expansion into new locations without significant changes to the core architecture.

#### Optional Enhancements:

1. **Loyalty Program Integration:**
   - Integrate a loyalty program to reward frequent guests with discounts, upgrades, or complimentary services.

2. **Feedback and Rating System:**
   - Include a system for guests to provide feedback on their stay and rate the hotel’s services, helping future guests make informed decisions.
