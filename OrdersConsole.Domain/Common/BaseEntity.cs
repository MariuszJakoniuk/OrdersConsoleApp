namespace OrdersConsole.Domain.Common;
public class BaseEntity : AuditableModel
{
    [XmlAttribute("Id")]
    public int Id { get; set; }
}