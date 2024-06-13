This task should be easy enough to start.

Create a console application in C# that simulates a hotel booking service. The application should allow users to:
1. Book a room
2. List all current bookings

The application should start with a welcome message and display a menu:
1. Book a room
2. List all bookings
3. Exit

Booking a Room:
- When the user chooses to book a room, prompt for the following details:
  - Guest name
  - Room number
  - Check-in date
  - Check-out date
- Add the new record to an Array (or List) of Bookings

List all bookings:
- Print the Array (or List) of Bookings

Classes to implement:
- Booking (guest name, room number, check in date, check out date)

Data storage:
- Use an in-memory array/list to store the booking information.
- Each booking should be represented by an object with appropriate properties.

Additional Features (Optional):
- Input Validation: Ensure all user inputs are valid (e.g. room numbers are integers, dates are in the correct format).
- Room class: Instead of just a room number in a Booking class, save a reference to a Room object that contains room-specific attributes (e.g. room number, price and comfort level)