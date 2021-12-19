namespace OrdersConsoleApp;

public class Order
{
    public int Id { get; set; }
    public OrderType TypeId { get; set; }
    public string Name { get; set; }
    public DateTime OrderDate { get; set; }
    public OrderStatus StatusId { get; set; }
    public DateTime Dedline { get; set; }
}
