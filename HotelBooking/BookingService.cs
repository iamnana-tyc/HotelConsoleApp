public class BookingService {
    private List<Booking> bookings = new List<Booking>();
    private List<Room> rooms = new List<Room>();

    // a method to add a booking
    public void BookAHotel(string guestName, int roomNumber, DateTime checkInDate, DateTime checkOutDate){

        Room? myRoom = rooms.Find(r => r.RoomNumber == roomNumber);
        if( myRoom != null){
            Booking bookAHotel = new Booking(guestName, myRoom, checkInDate, checkOutDate);
            bookings.Add(bookAHotel);
        }else
        Console.WriteLine("Room not found!");
        
    }

    public void ListAllBooking(){
        if(bookings.Count == 0 ){
            Console.WriteLine("No booking have been made!!");
            Console.WriteLine("Please, go ahead to book a room");
        }else
        {
            Console.WriteLine("Here are the list of bookings.");
            foreach(Booking booking in bookings){
            Console.WriteLine(booking);
        }
        }
        
    }

     // Add a room
    public void AddARoom(Room room){
        rooms.Add(room);
    }
}