namespace OrdersConsole.App.Concrete;
public class OrderStatusService:BaseService<OrderStatus>
{
    public OrderStatusService()
    {
        Initialize();
    }

    public void Initialize()
    {
        AddItem( new OrderStatus(1, "Nowe"));
        AddItem(new OrderStatus(2, "W realizacji"));
        AddItem(new OrderStatus(3, "Zrealizowane"));
    }
}
