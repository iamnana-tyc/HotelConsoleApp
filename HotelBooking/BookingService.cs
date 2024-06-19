public class BookingService
{
    private List<Booking> bookings = new List<Booking>();
    private List<Room> rooms = new List<Room>();

    // a method to add a booking
    public void BookAHotel(Booking booking)
    {
        bookings.Add(booking);
    }

    public void ListAllBooking()
    {
        if (bookings.Count == 0)
        {
            Console.WriteLine("No booking have been made!!");
            Console.WriteLine("Please, go ahead to book a room");
        }
        else
        {
            Console.WriteLine("Here are the list of bookings.");
            foreach (Booking booking in bookings)
            {
                Console.WriteLine(booking);
            }
        }

    }

    // Add a room
    public void AddARoom(Room room)
    {
        rooms.Add(room);
    }

    public void ListRooms()
    {
        if (rooms.Count == 0)
        {
            Console.WriteLine("There are no rooms");
        }
        else
        {
            foreach (Room room in rooms)
            {
                Console.WriteLine(room);
            }
        }
    }

    public Room FindARoom(int roomNumber)
    {
        return rooms.Find(r => r.RoomNumber == roomNumber);
    }

    public int InputInt(string prompt, int minValue, int maxValue)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (int.TryParse(input, out int value) && value >= minValue && value <= maxValue)
            {
                return value;
            }
            else
                Console.WriteLine("You have typed the wrong input values");
        }

    }

    public DateTime InputDateTime(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (DateTime.TryParse(input, out DateTime date))
            {
                return date;
            }
            else
                Console.WriteLine("Please enter the correct date format: yyy-mm-dd");
        }
    }

    public string InputString(string prompt)
    {

        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                return input;
            }
            else
                Console.WriteLine("The input can't be empty");
        }
    }


    // Least priced room
    public void FindLeastPricedRoom()
    {
        decimal leastPrice = rooms.Min(room => room.Price);
        Room leastPricedRoom = rooms.First(room => room.Price == leastPrice);
        Console.WriteLine($" Hey, Just so you know, the least Price in this Hotel is: {leastPricedRoom.Price}");
    }

    // Average comfort level

    public void ShowAverageComfortLevel()
    {
        double averageComfortLevel = rooms.Average(room => room.ComfortLevel);
        Console.WriteLine($"The average comfortel level is: {averageComfortLevel}");
    }

    // Long booking less than 7 days 
    public void LongBookingLessThan7Days()
    {
        var longBookings = bookings.Where(booking => booking.Duaration > 7);
        foreach (var booking in longBookings)
        {
            Console.WriteLine($" The longest booking is guest: {booking.GuestName}, room: {booking.Room.RoomNumber}, duration: {booking.Duaration} days");
        }
    }

    // Avg number of days booked per one booking
    public void NumberOfDaysBookedPerBooking()
    {
        var daysBookedPerBooking = bookings.Average(booking => booking.Duaration);
        Console.WriteLine("The average number of days booked per one booking is: " + daysBookedPerBooking);
    }
    // list all bookings for specific room
    public void ListOfAllBookingForSpecificRoom(int roomNumber)
    {
        var specificRoom = bookings.Where(booking => booking.Room.RoomNumber == roomNumber);

        if (!specificRoom.Any())
        {
            Console.WriteLine($"There are no booking for room number {roomNumber} yet");
            return;
        }
        Console.WriteLine($"Here are bookings for room number {roomNumber}");
        foreach (var booking in specificRoom)
        {
            Console.WriteLine(booking);
        }

    }

    // List rooms that are free at a specific day
    public void AllRoomsFreeAtSpecificDay(DateTime date)
    {
        // check the booked rooms
        var bookedRooms = bookings.Where(booking => booking.CheckInDate <= date && booking.CheckOutDate >= date)
        .Select(booking => booking.Room.RoomNumber);

        // find the free rooms
        var freeRooms = rooms.Where(room => !bookedRooms.Contains(room.RoomNumber));

        if (!freeRooms.Any())
        {
            Console.WriteLine($"There are no free room available on this dates {date.ToShortDateString()}");
        }
        Console.WriteLine($"Here are available rooms free on: {date.ToShortDateString()}");
        foreach (var room in freeRooms)
        {
            Console.WriteLine(room);
        }
    }

    public void TotalRevenueForEachRoom()
    {
        var revenuePerEachRoom = from booking in bookings
                                 group booking by booking.Room.RoomNumber into someRomeGroup
                                 select new
                                 {
                                     roomNumber = someRomeGroup.Key,
                                     totalRevenue = someRomeGroup.Sum(booking => booking.Duaration * booking.Room.Price)
                                 };
        Console.WriteLine("Total revenue per room ");

        foreach (var revenueEachRoom in revenuePerEachRoom)
        {
            Console.WriteLine($"Room number: {revenueEachRoom.roomNumber}, Total Revenue: {revenueEachRoom.totalRevenue}");
        }

    }

    public void TotalRevenueForAllRooms()
    {
        decimal totalRevenueForAllRooms = bookings.Sum(booking => booking.Duaration * booking.Room.Price);
        Console.WriteLine($"Total revenue for all rooms booked: {totalRevenueForAllRooms}");
    }
}