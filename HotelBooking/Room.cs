public class Room : BaseEntity
{
    public int RoomNumber { get; set; }
    public decimal Price { get; set; }

    public int ComfortLevel { get; set; }

    public Room(int roomNumber, decimal price, int comfortLevel)
    {
        this.RoomNumber = roomNumber;
        this.Price = price;
        this.ComfortLevel = comfortLevel;

    }
    // Overiding the Display method in BaseEntiry
    public override string Display()
    {
        return $"{base.Display()}, RoomNumber: {RoomNumber}, Price:{Price}";
    }
    public override string ToString()
    {
        return $"Room: {RoomNumber}, Price: {Price}, ComfortLevel: {ComfortLevel}";
    }
}