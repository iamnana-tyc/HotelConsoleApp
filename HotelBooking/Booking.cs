using System.Dynamic;

public class Booking
{

    //  Booking (guest name, room number, check in date, check out date)

    public string GuestName { get; set; }

    public Room Room { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }

    public int Duaration => (CheckOutDate - CheckInDate).Days;



    public Booking(string GuestName, Room room, DateTime CheckInDate, DateTime CheckOutDate)
    {
        this.GuestName = GuestName;
        this.Room = room;
        this.CheckInDate = CheckInDate;
        this.CheckOutDate = CheckOutDate;
    }

    public override string ToString()
    {
        return $"GuestName: {GuestName}, RoomNumber: {Room}, from {CheckInDate.ToShortDateString()} to {CheckOutDate.ToShortDateString()}";
    }

}