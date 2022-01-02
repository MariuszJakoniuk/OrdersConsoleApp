namespace OrdersConsole.App.Concrete;
public class OrderService : BaseService<Order>
{
    public override bool UpdateItem(Order item)
    {
        var entity = GetItemById(item.Id);
        if (entity == null)
        {
            return false;
        }
        entity.TypeId = item.TypeId;
        entity.Name = item.Name;
        entity.OrderDate = item.OrderDate;
        entity.StatusId = item.StatusId;
        entity.Dedline = item.Dedline;
        EditModifedItems(entity);
        return true;
    }
}