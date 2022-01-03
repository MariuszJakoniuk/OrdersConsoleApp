namespace OrdersConsole.Domain.Entity;
public class Order : BaseEntity
{
    public byte TypeId { get; set; }
    public string? Name { get; set; }
    public DateTime OrderDate { get; set; }
    public byte StatusId { get; set; }
    public DateTime? Dedline { get; set; }
    
    public Order()
    {
    }

    public Order(Order order)
    {
        Id = order.Id;
        TypeId = order.TypeId;
        Name = order.Name;
        OrderDate = order.OrderDate;
        StatusId = order.StatusId;
        Dedline = order.Dedline;
        CreatedById = order.CreatedById;
        CreatedDateTime = order.CreatedDateTime;
        ModifiedById = order.ModifiedById;
        ModifiedDateTime = order.ModifiedDateTime;
    }
}
