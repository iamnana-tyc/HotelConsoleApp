class Program
{
    static void Main(string[] args)
    {

        BookingService bookingService = new BookingService();
        bool appStarts = true;


        // Adding some rooms to the booking service
        Room room1 = new Room(100, 150m, 2);
        Room room2 = new Room(200, 250m, 4);
        Room room3 = new Room(300, 400m, 5);

        bookingService.AddARoom(room1);
        bookingService.AddARoom(room2);
        bookingService.AddARoom(room3);

        // Adding some booking 
        Booking booking1 = new Booking(GuestName: "Tommy", room: room1, CheckInDate: new DateTime(2024, 7, 1), CheckOutDate: new DateTime(2024, 7, 6));
        Booking booking2 = new Booking(GuestName: "Evans", room: room2, CheckInDate: new DateTime(2024, 7, 11), CheckOutDate: new DateTime(2024, 7, 20));
        Booking booking3 = new Booking(GuestName: "John", room: room1, CheckInDate: new DateTime(2024, 7, 8), CheckOutDate: new DateTime(2024, 7, 11));
        Booking booking4 = new Booking(GuestName: "Gaby", room: room3, CheckInDate: new DateTime(2024, 7, 20), CheckOutDate: new DateTime(2024, 7, 30));

        bookingService.BookAHotel(booking1);
        bookingService.BookAHotel(booking2);
        bookingService.BookAHotel(booking3);
        bookingService.BookAHotel(booking4);
        /*
        bookingService.AddARoom(new Room(100, 150m, 2));
        bookingService.AddARoom(new Room(200, 250m, 4));
        bookingService.AddARoom(new Room(300, 350m, 5));
        */

        bookingService.FindLeastPricedRoom();

        Console.WriteLine();

        bookingService.ShowAverageComfortLevel();


        Console.WriteLine();
        Console.WriteLine("Welcome to Nana Resort Hotel");


        while (appStarts)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Book a Room");
            Console.WriteLine("2. List all Booking");
            Console.WriteLine("3. List all available Rooms");
            Console.WriteLine("4. List all bookings for specific Room");
            Console.WriteLine("5. List free rooms on a specific date");
            Console.WriteLine("6. List the total revenue for each room");
            Console.WriteLine("7. Exit");
            Console.WriteLine("Select an option from either: 1,2,3,4");

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
                    bookingService.ListAllBooking();
                    break;

                case "3":
                    bookingService.ListRooms();
                    break;
                case "4":
                    Console.WriteLine("Enter the room number");
                    if (int.TryParse(Console.ReadLine(), out int roomNumber))
                    {
                        bookingService.ListOfAllBookingForSpecificRoom(roomNumber);
                    }
                    else
                        Console.WriteLine("The room number does't exist.");
                    break;
                case "5":
                    Console.Write("Enter the dates (yyy-mm-dd): ");
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
                    {
                        bookingService.AllRoomsFreeAtSpecificDay(date);
                    }
                    else
                        Console.WriteLine("Invalid input dates, please enter correct dates.");
                    break;
                case "6":
                    bookingService.TotalRevenueForAllRooms();
                    break;

                case "7":
                    appStarts = false;
                    Console.WriteLine("You have exit the app");
                    break;

                default:
                    Console.WriteLine("Invalid input, enter the correct option");
                    break;
            }
        }
        Console.WriteLine();

        bookingService.LongBookingLessThan7Days();

        Console.WriteLine();

        bookingService.NumberOfDaysBookedPerBooking();

        Console.WriteLine();

        bookingService.TotalRevenueForEachRoom();

    }

    static Booking? CreateABooking(BookingService bookingService)
    {
        bookingService.ListAllBooking();

        int roomNumber = bookingService.InputInt("Enter room number: ", 100, 300);
        Room room = bookingService.FindARoom(roomNumber);
        if (room == null)
        {
            Console.WriteLine("There is no such room");
            return null;
        }
        string guestName = bookingService.InputString("Enter the guest name: ");
        DateTime checkInDate = bookingService.InputDateTime("Enter check-in date (yyy-mm-dd): ");
        DateTime checkOutDate = bookingService.InputDateTime("Enter check-out date (yyy-mm-dd): ");

        return new Booking(guestName, room, checkInDate, checkOutDate);
    }

}
