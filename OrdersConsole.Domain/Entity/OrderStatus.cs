namespace OrdersConsole.Domain.Entity;
public class OrderStatus : BaseEntity
{
    public string? Name { get; set; }

    public OrderStatus()
    {
    }

    public OrderStatus(OrderStatus orderStatus)
    {
        Id = orderStatus.Id;
        Name = orderStatus.Name;
    }

    public OrderStatus(int id, string name)
    {
        Id = id;
        Name = name;
    }
}