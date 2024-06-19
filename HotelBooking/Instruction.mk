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


Rooms for improvement:
- More checks - if the user chooses wrong room, there is no message.
- BookARoom - i think it is better not to pass bookingService into this method, but have a separate method to create a Booking from input (returns Booking), and do bookingService.BookAHotel(booking); on another line in Program.cs.
- Some code formatting in BookingService
- separate static class for Input methods (for ex. "InputInt" method that allows to input integer in specified range; InputDate which allows to input date in specified range).

Queries using LINQ 
Easy:
1. Average comfort level of rooms
2. Least priced room
3. Long bookings (>7 days)

Medium:
1. Avg number of days booked per one booking
2. List all bookings for a specific room
3. List rooms that are free at a specific day

Complex:
1. Total revenue for each room (price of room * days booked), and total revenue for all rooms
You may invent some of your own queries.

Recommendations:
- Prepare all records beforehand in code (create sample bookings/rooms in code so not to recreate them each time by hand)
- Make a separate sub-menu for queries
- Create a separate method for each query. You may (or may not - if you got better ideas) put them in a separate static class "Queries".
- Use IEnumerable where possible instead of List (you may start with List, but then change your methods to receive/return IEnumerable instead; at any time you may convert IEnumerable to List with .ToList() method).