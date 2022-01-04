namespace OrdersConsole.Domain.Entity;
public class Order : BaseEntity
{
    [XmlElement("TypeId")]
    public byte TypeId { get; set; }
    [XmlElement("Name")]
    public string? Name { get; set; }
    [XmlElement("OrderDate")]
    public DateTime OrderDate { get; set; }
    [XmlElement("StatusId")]
    public byte StatusId { get; set; }
    [XmlElement("Dedline")]
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
