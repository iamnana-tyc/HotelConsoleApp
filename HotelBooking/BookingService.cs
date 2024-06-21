public class BookingService
{
    private List<Booking> bookings = new List<Booking>();
    private List<Room> rooms = new List<Room>();

    public List<Booking> Bookings => bookings;
    public List<Room> Rooms => rooms;

    // a method to add a booking
    public void BookAHotel(Booking booking)
    {
        bookings.Add(booking);
    }
    // Add a room
    public void AddARoom(Room room)
    {
        rooms.Add(room);
    }
}