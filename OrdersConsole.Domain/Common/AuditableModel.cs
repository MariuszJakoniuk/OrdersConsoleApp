namespace OrdersConsole.Domain.Common;
public class AuditableModel
{
    [XmlElement("CreatedById")]
    public string? CreatedById { get; set; }
    [XmlElement("CreatedDateTime")]
    public DateTime? CreatedDateTime { get; set; }
    [XmlElement("ModifiedById")]
    public string? ModifiedById { get; set; }
    [XmlElement("ModifiedDateTime")]
    public DateTime? ModifiedDateTime { get; set; }
}