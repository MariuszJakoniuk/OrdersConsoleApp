namespace OrdersConsole.App.Managers;
public class OrderManager
{
    private IService<Order> _orderService;
    private OrderTypeService orderType { get; init; }
    private OrderStatusService orderStatus { get; set; }

    public OrderManager(IService<Order> orderService)
    {
        _orderService = orderService;
        orderType = new OrderTypeService();
        orderStatus = new OrderStatusService();
    }

    public int AddNewOrders()
    {
        Console.Clear();
        Console.WriteLine("Wybiez typ zamówienia: ");
        byte[] operationAccepted = new byte[this.orderType.Items.Count];
        for (int i = 0; i < orderType.Items.Count; i++)
        {
            Console.WriteLine($"{orderType.Items[i].Id}. {orderType.Items[i].Name}");
            operationAccepted[i] = (byte)orderType.Items[i].Id;
        }
        byte operation = Validation.GiveMeByte("Dokonaj wyboru: ", operationAccepted);

        Order order = new Order();
        order.TypeId = operation;
        order.Id = _orderService.GetLastId() + 1;
        order.Name = Validation.GiveMeString("Podaj nazwe zamówienia: ");
        order.OrderDate = DateTime.Now;

        Console.WriteLine("Status zamówienia: ");
        operationAccepted = new byte[orderStatus.Items.Count];
        for (int i = 0; i < orderStatus.Items.Count; i++)
        {
            Console.WriteLine($"{orderStatus.Items[i].Id}. {orderStatus.Items[i].Name}");
            operationAccepted[i] = (byte)orderStatus.Items[i].Id;
        }
        operation = Validation.GiveMeByte("Dokonaj wyboru: ", operationAccepted);
        order.StatusId = operation;

        if (Validation.GiveMeChar("Czy zamówienie ma termin realizacji? (T)ak/(N)ie: ", new char[] { 'T', 'N' }) == "T")
        {
            order.Dedline = Validation.GiveMeDate();
        }
        else
        {
            order.Dedline = null;
        }
        _orderService.AddItem(new Order(order));

        return order.Id;
    }

    private void ShowOdrerDetails(Order order)
    {
        string? text = "";
        Console.Write("|");
        text = ("   " + order.Id).Substring(("   " + order.Id).Length - 3, 3);
        Console.Write(text);
        Console.Write("|");

        OrderType? type = orderType.GetItemById(order.TypeId);
        string textCheck = "";
        if (type != null)
        {
            textCheck = type.Name != null ? type.Name : "";
        }
        text = $"{textCheck}         ".Substring(0, 8);
        Console.Write(text);
        Console.Write("|");
        text = (order.Name + "                              ").Substring(0, 29);
        Console.Write(text);
        Console.Write("|");
        text = order.OrderDate.ToShortDateString();
        Console.Write(text);
        Console.Write("|");

        OrderStatus? status = orderStatus.GetItemById(order.StatusId);
        textCheck = "";
        if (status != null)
        {
            textCheck = status.Name != null ? status.Name : "";
        }
        text = $"{textCheck}              ".Substring(0, 12);
        Console.Write(text);
        Console.Write("|");
        text = order.Dedline == null ? "          " : ((DateTime)order.Dedline).ToShortDateString();
        Console.Write(text);
        Console.WriteLine("|");
    }

    public int ShowOrder()
    {
        int count = 0;

        ShowOrdersTop();
        foreach (Order order in _orderService.Items)
        {
            ShowOdrerDetails(order);
            count++;
        }
        if (count == 0)
        {
            Console.WriteLine("Brak zamówień");
        }
        ShowOrderLine();
        Console.WriteLine();

        return count;
    }

    public int ShowOrder(int id)
    {
        Order? order = _orderService.GetItemById(id);
        ShowOrdersTop();
        if (order != null)
        {
            ShowOdrerDetails(order);
            ShowOrderLine();
            return 1;
        }
        else
        {
            Console.WriteLine("Brak zamówień zgodnych ze specyfikacją");
            ShowOrderLine();
            return 0;
        }
    }

    private void ShowOrdersTop()
    {
        Console.Clear();
        Console.WriteLine("                                Lista zamówień                                 ");
        ShowOrderLine();
        Console.WriteLine("|Id.|  Typ   |Nazwa                        | Wpłneło  |Zrealizowane|  Termin  |");
        ShowOrderLine();
    }

    private void ShowOrderLine()
    {
        Console.WriteLine("+---+--------+-----------------------------+----------+------------+----------+");
    }

    public int OrderStatusChange(int idChange)
    {
        Order? orderChange = _orderService.GetItemById(idChange);
        if (orderChange == null)
        {
            return 0;
        }
        Order order = new Order(orderChange);
        int toChange = ShowOrder(idChange);
        Console.WriteLine();

        int count = 0;

        if (toChange != 0)
        {
            byte[] operationAccepted = new byte[orderStatus.Items.Count];
            for (int i = 0; i < orderStatus.Items.Count; i++)
            {
                Console.WriteLine($"{orderStatus.Items[i].Id}. {orderStatus.Items[i].Name}");
                operationAccepted[i] = (byte)orderStatus.Items[i].Id;
            }
            byte statusNew = Validation.GiveMeByte("Dokonaj wyboru: ", operationAccepted);

            if (order.StatusId != statusNew)
            {
                order.StatusId = statusNew;
                UpdateItemStatus(idChange, statusNew);
                //_orderService.UpdateItem(order);
                count++;
                ShowOrder(idChange);
            }
            else
            {
                Console.WriteLine("Nie zmieniłeś statusu.");
            }
        }
        else
        {
            Console.WriteLine($"Podany id {idChange} zamówienia nie istnieje");
        }
        Console.WriteLine("\n\rNaciśnij klawisz by wyjść.");
        Console.ReadKey();
        return count;
    }

    public int RemoveOrder(int idRemove)
    {
        int toRemove = ShowOrder(idRemove);
        Console.WriteLine();

        int count = 0;

        if (toRemove != 0)
        {
            if (Validation.GiveMeChar("Czy usunąć zamówienie? (T)ak/(N)ie: ", new char[] { 'T', 'N' }) == "T")
            {
                _orderService.RemoveItemById(idRemove);
                Console.WriteLine("Zamówienie usuniete.");
                count++;
            }
            else
            {
                Console.WriteLine("Rezygnacja z ununięcia zamówienia.");
            }
        }
        else
        {
            Console.WriteLine($"Podany id {idRemove} zamówienia nie istnieje");
        }
        Console.WriteLine("\n\rNaciśnij klawisz by wyjść.");
        Console.ReadKey();
        return count;
    }

    public int EditOrder(int idEdit)
    {
        Order? orderEdit = _orderService.GetItemById(idEdit);
        if (orderEdit == null)
        {
            return 0;
        }
        Order order = new Order(orderEdit);
        int toEdit = ShowOrder(idEdit);
        Console.WriteLine();

        int count = 0;

        if (toEdit != 0)
        {
            if (Validation.GiveMeChar("Czy zmienić typ zamówienia? (T)ak/(N)ie: ", new char[] { 'T', 'N' }) == "T")
            {
                byte[] operationAccepted = new byte[orderType.Items.Count];
                for (int i = 0; i < orderType.Items.Count; i++)
                {
                    Console.WriteLine($"{orderType.Items[i].Id}. {orderType.Items[i].Name}");
                    operationAccepted[i] = (byte)orderType.Items[i].Id;
                }
                byte typeNew = Validation.GiveMeByte("Dokonaj wyboru: ", operationAccepted);
                if (order.TypeId != typeNew)
                {
                    order.TypeId = typeNew;
                    count++;
                }
            }
            if (Validation.GiveMeChar("Czy zmienić nazwę zamówienia? (T)ak/(N)ie: ", new char[] { 'T', 'N' }) == "T")
            {
                order.Name = Validation.GiveMeString("Nowa nazwa zamówienia: ");
                count++;
            }
            if (Validation.GiveMeChar("Czy zmienić datę wpłyniecia zamówienia? (T)ak/(N)ie: ", new char[] { 'T', 'N' }) == "T")
            {
                order.OrderDate = Validation.GiveMeDate();
                count++;
            }
            if (Validation.GiveMeChar("Czy zmienić status zamówienia? (T)ak/(N)ie: ", new char[] { 'T', 'N' }) == "T")
            {
                byte[] operationAccepted = new byte[orderStatus.Items.Count];
                for (int i = 0; i < orderStatus.Items.Count; i++)
                {
                    Console.WriteLine($"{orderStatus.Items[i].Id}. {orderStatus.Items[i].Name}");
                    operationAccepted[i] = (byte)orderStatus.Items[i].Id;
                }
                byte statusNew = Validation.GiveMeByte("Dokonaj wyboru: ", operationAccepted);
                if (order.StatusId != statusNew)
                {
                    order.StatusId = statusNew;
                    count++;
                }
            }
            if (Validation.GiveMeChar("Czy zmienić datę realizacji zamówienia? (T)ak/(N)ie: ", new char[] { 'T', 'N' }) == "T")
            {
                order.Dedline = Validation.GiveMeDate();
                count++;
            }
            if (count != 0)
            {
                _orderService.UpdateItem(order);
                ShowOrder(idEdit);
            }
            else
            {
                Console.WriteLine("Nie wprowadzono zmian w zamówieniu.");
            }
        }
        else
        {
            Console.WriteLine($"Podany id {idEdit} zamówienia nie istnieje");
        }
        Console.WriteLine("\n\rNaciśnij klawisz by wyjść.");
        Console.ReadKey();
        return count;
    }

    public bool UpdateItemStatus(int id, byte newStaus)
    {
        var entity = _orderService.GetItemById(id);
        if (entity == null)
        {
            return false;
        }
        entity.StatusId = newStaus;
        _orderService.EditModifedItems(entity);
        _orderService.SaveItems();
        return true;
    }

    //Na potrzeby testów
    public Order? GetItemByIdTest(int id)
    {
        var item = _orderService.GetItemById(id);
        return item;
    }
}
