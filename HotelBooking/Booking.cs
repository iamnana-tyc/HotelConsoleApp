using System.Dynamic;

public class Booking : BaseEntity
{
    public string GuestName { get; set; }

    public Room Room { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }

    public int Duration => (CheckOutDate - CheckInDate).Days;

    // Overiding the Display method in BaseEntiry

    public override string Display()
    {
        return $"{base.Display()},  CheckInDate: {CheckInDate}, CheckOutDate: {CheckOutDate}, Duration:{Duration}";
    }

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