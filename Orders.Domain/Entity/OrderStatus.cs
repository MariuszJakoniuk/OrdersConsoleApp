namespace Orders.Domain.Entity;
public class OrderStatus : BaseEntity
{
    public string Name { get; set; }

    public OrderStatus(int id, string name)
    {
        Id = id;
        Name = name;
    }
}