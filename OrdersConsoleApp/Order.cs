namespace OrdersConsoleApp;

public class Order
{
    public int Id { get; set; }
    public byte TypeID { get; set; }
    public string? Name { get; set; }
    public DateTime OrderDate { get; set; }
    public byte StatusId { get; set; }
    public DateTime? Dedline { get; set; }

}
