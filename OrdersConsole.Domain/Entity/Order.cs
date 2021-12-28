namespace OrdersConsole.Domain.Entity;
public class Order : BaseEntity
{
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
    public Order()
    {
    }

    public Order(int id, byte typeId, string name, DateTime orderDate, byte statusId, DateTime? dedline, int createById, DateTime createDataTime, int? modifileById, DateTime? modifiedDateDime)
    {
        Id= id;
        TypeId = typeId;
        Name = name;
        OrderDate = orderDate;
        StatusId = statusId;
        Dedline = dedline;
        CreatedById = createById;
        CreatedDateTime = createDataTime;
        ModifiedById = modifileById;
        ModifiedDateTime = modifiedDateDime;
    }

    public byte TypeId { get; set; }
    public string Name { get; set; }
    public DateTime OrderDate { get; set; }
    public byte StatusId { get; set; }
    public DateTime? Dedline { get; set; }
}
