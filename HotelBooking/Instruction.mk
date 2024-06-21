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


Improvements:
- Input methods better stay in their own static class (like Input, and be used like Input.InputString(...)), not in BookingService - cuz they are not done specifically for this service, they may be used everywhere throughout your console application
- Query methods better stay in their own static class (like Query and be used like Query.AllBookings(...)).
- Query methods better take List of rooms/bookings as input and also return a List of rooms/bookings that aligned with your filter (or just return an integer, if a sum is calculated, for example). 
This way you separate business login in separate method and print the result afterwards - good programming is done this way (after some time you will understand from experience why it is done like this - it makes code more flexible). 
But your LINQs are not that complex at the moment, it is not really that necessary. But remember separating business logic is good.

Next task:
Expand the existing Room and Booking model by implementing an interface and using class inheritance. This task will help you understand and practice the concepts of interfaces and inheritance in C#.

1. Create an Interface: IIdentifiable
- Define an interface named IIdentifiable.
- This interface should include a single property Id of type int.
- Both Room and Booking classes should implement this interface.

2. Create a Base Class: BaseEntity
- Create a base class named BaseEntity.
- This class should implement the IIdentifiable interface.
- Include an Id property of type int in this class.
- Both Room and Booking classes should inherit from BaseEntity.

3. Implement a Display Method:
- In the IIdentifiable class, add a method Display() - we require all classes that implement this interface to have this method
- In the BaseEntity class, override Display() method and return the name of the class (this.GetType().Name) with its Id.
- In the Room and Booking classes override Display() to display additional information (e.g., RoomNumber for Room, and StartDate, EndDate for Booking) along with name of the class and Id.

4. Testing base entities:
- Create a list of BaseEntity that would include all your Rooms and Bookings; add a method to main program to print all created entities
- Iterate over instances of BaseEntity and call Display() method. Explain the results (why it includes specific properties or not?)

5. Testing interfaces:
- Create a list of IIdentifiable objects in the Main method.
- Add instances of Room and Booking to this list.
- Iterate through the list and call the Display() method on each item to demonstrate late binding. Explain the results (why it includes specific properties or not?)