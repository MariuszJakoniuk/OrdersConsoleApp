namespace Orders.App.Concrete;
public class OrderTypeService : BaseService<OrderType>
{
    public OrderTypeService()
    {
        Initialize();
    }

    public void Initialize()
    {
        AddItem(new OrderType(1, "Klient"));
        AddItem(new OrderType(2, "Dostawca"));
    }
}