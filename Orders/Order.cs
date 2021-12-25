namespace Orders;
public class Order
{
    public int Id { get; set; }
    public byte TypeId { get; set; }
    public string? Name { get; set; }
    public DateTime OrderDate { get; set; }
    public byte StatusId { get; set; }
    public DateTime? Dedline { get; set; }
}
