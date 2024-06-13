class Program
{
    static void Main(string[] args)
    {

        BookingService bookingService = new BookingService();
        bool appStarts = true;

         // Adding some rooms to the booking service
        bookingService.AddARoom(new Room(100, 150m, "Standard"));
        bookingService.AddARoom(new Room(200, 250m, "Business"));
        bookingService.AddARoom(new Room(300, 350m, "Suite"));

        Console.WriteLine("Welcome to Nana Resort Hotel");

        while (appStarts)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Book a Room");
            Console.WriteLine("2. List all Booking");
            Console.WriteLine("3. Exit");
            Console.WriteLine("Select an option from either: 1,2,3");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    BookARoom(bookingService);
                    break;

                case "2":
                    bookingService.ListAllBooking();
                    break;

                case "3":
                    appStarts = false;
                    Console.WriteLine("You have exit the app");
                    break;

                default:
                    Console.WriteLine("Invalid input, enter the correct option");
                    break;
            }
        }
    }

    static void BookARoom(BookingService bookingService)
    {
        try
        {
            Console.WriteLine("Enter guest name: ");
            string guestName = Console.ReadLine();

            Console.WriteLine("Enter a room number: ");
            int roomNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter check-in  date");
            DateTime checkInDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter check-out  date");
            DateTime checkOutDate = DateTime.Parse(Console.ReadLine());

            bookingService.BookAHotel(guestName, roomNumber, checkInDate, checkOutDate);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

}






