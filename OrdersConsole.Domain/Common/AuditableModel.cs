namespace OrdersConsole.Domain.Common;
public class AuditableModel
{
    public string? CreatedById { get; set; }
    public DateTime? CreatedDateTime { get; set; }
    public string? ModifiedById { get; set; }
    public DateTime? ModifiedDateTime { get; set; }
}