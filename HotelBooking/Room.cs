public class Room
{
    public int RoomNumber {get; set;}
    public decimal Price {get; set;}

    public string ComfortLevel {get; set;}

    public Room(int roomNumber, decimal price, string comfortLevel)
    {
        this.RoomNumber = roomNumber;
        this.Price = price;
        this.ComfortLevel = comfortLevel;
    }

    public override string ToString()
    {
        return $"Room: {RoomNumber}, Price: {Price}, ComfortLevel: {ComfortLevel}";
    }
}