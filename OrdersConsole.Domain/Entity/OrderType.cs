namespace OrdersConsole.Domain.Entity;
public class OrderType : BaseEntity
{
    public string Name { get; set; }

    public OrderType(int id, string name)
    {
        Id = id;
        Name = name;
    }
}