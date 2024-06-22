using System.Data.Common;

class Program
{
    static void Main(string[] args)
    {
        List<IIdentifiable> identifiableObjects = new List<IIdentifiable>();

        List<BaseEntity> baseEntities = new List<BaseEntity>();

        BookingService bookingService = new BookingService();



        bool appStarts = true;

        Query.Initialiaze(bookingService.Rooms, bookingService.Bookings);

        // Adding rooms
        Room room1 = new Room(100, 150m, 2);
        Room room2 = new Room(200, 250m, 4);
        Room room3 = new Room(300, 400m, 5);


        bookingService.AddARoom(room1);
        bookingService.AddARoom(room2);
        bookingService.AddARoom(room3);

        // booking a room
        Booking booking1 = new Booking(GuestName: "Tommy", room: room1, CheckInDate: new DateTime(2024, 7, 1), CheckOutDate: new DateTime(2024, 7, 6));
        Booking booking2 = new Booking(GuestName: "Evans", room: room2, CheckInDate: new DateTime(2024, 7, 11), CheckOutDate: new DateTime(2024, 7, 20));
        Booking booking3 = new Booking(GuestName: "John", room: room1, CheckInDate: new DateTime(2024, 7, 8), CheckOutDate: new DateTime(2024, 7, 11));
        Booking booking4 = new Booking(GuestName: "Gaby", room: room3, CheckInDate: new DateTime(2024, 7, 20), CheckOutDate: new DateTime(2024, 7, 30));


        bookingService.BookAHotel(booking1);
        bookingService.BookAHotel(booking2);
        bookingService.BookAHotel(booking3);
        bookingService.BookAHotel(booking4);



        // You should uncomment this part to be able to test the case for interface

        /*

                // adding rooms to the baseentities
                baseEntities.Add(room1);
                baseEntities.Add(room2);
                baseEntities.Add(room3);

                // adding booking to baseentities

                baseEntities.Add(booking1);
                baseEntities.Add(booking2);
                baseEntities.Add(booking3);
                baseEntities.Add(booking4);

                // display entities
                DisplayEntities(baseEntities);

                // a method to print all entities
                static void DisplayEntities(List<BaseEntity> baseEntities){
                    foreach(var entities in baseEntities){
                        Console.WriteLine(entities.Display());
                    }

                }

                 // EXPLANATION
                 // we are able to display the propeties of the Room and book using the display method in the base Entity class.
                 // Both classes are using the same Display method, however at run time the Display method display the properties that are 
                 // relevant to the actual object. So in this case:
                 // the display method displays room number and price, whereas for the Booking it displays 
                 // check-in date, check-out and duration. This 
                 // Both sub classes are using the same display method yet at run time, the display method displays the 
                 // propeties relevant to the class
            

        // adding rooms to the indentifiableobject
        identifiableObjects.Add(room1);
        identifiableObjects.Add(room2);
        identifiableObjects.Add(room3);

        // adding booking to identifiable list
        identifiableObjects.Add(booking1);
        identifiableObjects.Add(booking2);
        identifiableObjects.Add(booking3);
        identifiableObjects.Add(booking4);

        Display2Entities(identifiableObjects);

        static void Display2Entities(List<IIdentifiable> identifiables)
        {
            foreach (var identifiable in identifiables)
            {
                Console.WriteLine(identifiable.Display());
            }
        }

        // EXPLANATION
        // The interface which is IIdentifiable has a method call Display. This Superclass makes sure that 
        // both Room and Booking which are all subclasses implement the display method. 
        // However during run time the Display method shows different output based on the object type 
        // so we see that for Room Display method shows Room number and price, and for Booking,
        // it shows the check-in date, check-out and duration even though they both running the same Display method.  


        */



        Query.FindLeastPricedRoom();

        Console.WriteLine();

        Query.ShowAverageComfortLevel();


        Console.WriteLine();
        Console.WriteLine("Welcome to Nana Resort Hotel");


        while (appStarts)
        {
            Console.WriteLine("Main menu:");
            Console.WriteLine("1. Book a Room");
            Console.WriteLine("2. List all Booking");
            Console.WriteLine("3. List all available Rooms");
            Console.WriteLine("4. show query menu");
            Console.WriteLine("5. Exit");
            Console.WriteLine("Select an option from either: 1,2,3,4,5");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Booking booking = CreateABooking(bookingService);
                    if (booking != null)
                    {
                        bookingService.BookAHotel(booking);
                    }
                    break;

                case "2":
                    Query.ListAllBooking();
                    break;

                case "3":
                    Query.ListRooms();
                    break;
                case "4":
                    ShowQueryMenu(bookingService);
                    break;
                case "5":
                    appStarts = false;
                    Console.WriteLine("You have exit the app");
                    break;

                default:
                    Console.WriteLine("Invalid input, enter the correct option");
                    break;
            }
        }
        Console.WriteLine();

        Query.LongBookingLessThan7Days();

        Console.WriteLine();

        Query.NumberOfDaysBookedPerBooking();

        Console.WriteLine();

        Query.TotalRevenueForEachRoom();


    }

    static Booking? CreateABooking(BookingService bookingService)
    {
        Query.ListAllBooking();

        int roomNumber = Input.InputInt("Enter room number: ", 100, 300);
        Room room = Query.FindARoom(roomNumber);
        if (room == null)
        {
            Console.WriteLine("There is no such room");
            return null;
        }
        string guestName = Input.InputString("Enter the guest name: ");
        DateTime checkInDate = Input.InputDateTime("Enter check-in date (yyy-mm-dd): ");
        DateTime checkOutDate = Input.InputDateTime("Enter check-out date (yyy-mm-dd): ");

        return new Booking(guestName, room, checkInDate, checkOutDate);
    }

    static void ShowQueryMenu(BookingService bookingService)
    {
        bool queryMenuOnly = true;
        while (queryMenuOnly)
        {

            Console.WriteLine("Query Menu");
            Console.WriteLine("1. List all booking for specific room");
            Console.WriteLine("2. List all free rooms on a specific date");
            Console.WriteLine("3. List the total revenue for each room");
            Console.WriteLine("4. Return to the Main Menu");
            Console.WriteLine("Select any of these options: 1, 2, 3, 4");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.WriteLine("Enter the room number");
                    if (int.TryParse(Console.ReadLine(), out int roomNumber))
                    {
                        Query.ListOfAllBookingForSpecificRoom(roomNumber);
                    }
                    else
                        Console.WriteLine("The room number does't exist.");
                    break;
                case "2":
                    Console.Write("Enter the dates (yyy-mm-dd): ");
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
                    {
                        Query.AllRoomsFreeAtSpecificDay(date);
                    }
                    else
                        Console.WriteLine("Invalid input dates, please enter correct dates.");
                    break;
                case "3":
                    Query.TotalRevenueForAllRooms();
                    break;
                case "4":
                    queryMenuOnly = false;
                    break;

                default:
                    Console.WriteLine("Invalid input, enter the correct option");
                    break;

            }

        }

    }

}
