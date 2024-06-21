public static class Query
{

    private static List<Booking> bookings;
    private static List<Room> rooms;

    public static void Initialiaze(List<Room> roomList, List<Booking> bookingList)
    {
        rooms = roomList;
        bookings = bookingList;

    }
    public static Room FindARoom(int roomNumber)
    {
        return rooms.Find(r => r.RoomNumber == roomNumber);
    }

    public static void ListRooms()
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

    public static void ListAllBooking()
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

    // Least priced room
    public static void FindLeastPricedRoom()
    {

        if (rooms.Count == 0)
        {
            Console.WriteLine("No rooms available to find the least priced. ");
            return;

        }

        decimal leastPrice = rooms.Min(room => room.Price);
        Room leastPricedRoom = rooms.First(room => room.Price == leastPrice);
        Console.WriteLine($" Hey, Just so you know, the least Price in this Hotel is: {leastPricedRoom.Price}");
    }

    // Average comfort level

    public static void ShowAverageComfortLevel()
    {
        if (rooms.Count == 0)
        {
            Console.WriteLine("No rooms yet to find the average comfort level");
            return;
        }
        double averageComfortLevel = rooms.Average(room => room.ComfortLevel);
        Console.WriteLine($"The average comfortel level is: {averageComfortLevel}");
    }

    // Long booking less than 7 days 
    public static void LongBookingLessThan7Days()
    {
        var longBookings = bookings.Where(booking => booking.Duration > 7);
        foreach (var booking in longBookings)
        {
            Console.WriteLine($" The longest booking is guest: {booking.GuestName}, room: {booking.Room.RoomNumber}, duration: {booking.Duration} days");
        }
    }

    // Avg number of days booked per one booking
    public static void NumberOfDaysBookedPerBooking()
    {
        var daysBookedPerBooking = bookings.Average(booking => booking.Duration);
        Console.WriteLine("The average number of days booked per one booking is: " + daysBookedPerBooking);
    }
    // list all bookings for specific room
    public static void ListOfAllBookingForSpecificRoom(int roomNumber)
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
    public static void AllRoomsFreeAtSpecificDay(DateTime date)
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


    public static void TotalRevenueForEachRoom()
    {
        var revenuePerEachRoom = from booking in bookings
                                 group booking by booking.Room.RoomNumber into someRomeGroup
                                 select new
                                 {
                                     roomNumber = someRomeGroup.Key,
                                     totalRevenue = someRomeGroup.Sum(booking => booking.Duration * booking.Room.Price)
                                 };
        Console.WriteLine("Total revenue per room ");

        foreach (var revenueEachRoom in revenuePerEachRoom)
        {
            Console.WriteLine($"Room number: {revenueEachRoom.roomNumber}, Total Revenue: {revenueEachRoom.totalRevenue}");
        }

    }

    public static void TotalRevenueForAllRooms()
    {
        decimal totalRevenueForAllRooms = bookings.Sum(booking => booking.Duration * booking.Room.Price);
        Console.WriteLine($"Total revenue for all rooms booked: {totalRevenueForAllRooms}");
    }
}