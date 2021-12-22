namespace OrdersConsoleApp;

public class OrderService
{
    public List<Order> Orders { get; set; }

    public OrderService()
    {
        Orders = new List<Order>();
    }

    public int AddNewOrders()
    {

        Console.WriteLine("Wybiez typ zamówienia: ");

        TypeOrderService typeOrderService = new TypeOrderService();
        typeOrderService.Initialize(typeOrderService);
        var menuAdd = typeOrderService.GetAllType();
        byte[] operationAccepted = new byte[menuAdd.Count];
        for (int i = 0; i < menuAdd.Count; i++)
        {
            Console.WriteLine($"{menuAdd[i].Id}. {menuAdd[i].Name}");
            operationAccepted[i] = (byte)menuAdd[i].Id;
        }
        byte operation = Validation.GiveMeByte("Dokonaj wyboru: ", operationAccepted);

        Order order = new Order();
        order.TypeID = operation;
        order.Id = Validation.GiveMeInt("Podaj Id zamówienia: ");
        order.Name = Validation.GiveMeString("Podaj nazwe zamówienia: ");
        order.OrderDate = DateTime.Now;

        Console.WriteLine("Status zamówienia: ");
        StatusOrderService statusOrderService = new StatusOrderService();
        statusOrderService.Initialize(statusOrderService);
        var statusAdd = statusOrderService.GetAllStatus();
        operationAccepted = new byte[statusAdd.Count];
        for (int i = 0; i < statusAdd.Count; i++)
        {
            Console.WriteLine($"{statusAdd[i].Id}. {statusAdd[i].Name}");
            operationAccepted[i] = (byte)statusAdd[i].Id;
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
        Orders.Add(order);

        return order.Id;
    }

    private void ShowOdrerDetails(Order order, List<TypeOrder> typeOrder, List<StatusOrder> statusOrder)
    {
        Console.Write("|");
        Console.Write(("   " + order.Id).Substring(("   " + order.Id).Length - 3, 3));
        Console.Write("|");
        for (int i = 0; i < typeOrder.Count; i++)
        {
            if (typeOrder[i].Id == order.Id)
            {
                Console.Write((typeOrder[i].Name + "         ").Substring(0, 8));
                break;
            }
        }
        Console.Write("|");
        Console.Write((order.Name + "                              ").Substring(0, 29));
        Console.Write("|");
        Console.Write(order.OrderDate.ToShortDateString());
        Console.Write("|");
        for (int i = 0; i < statusOrder.Count; i++)
        {
            if (statusOrder[i].Id == order.Id)
            {
                Console.Write((statusOrder[i].Name + "              ").Substring(0, 12));
                break;
            }
        }
        Console.Write("|");
        if (order.Dedline == null)
        {
            Console.Write("          ");
        }
        else
        {
            DateTime date = (DateTime)order.Dedline;
            Console.Write(date.ToShortDateString());
        }
        Console.WriteLine("|");
    }
    public int ShowOrder()
    {
        TypeOrderService typeOrderService = new TypeOrderService();
        typeOrderService.Initialize(typeOrderService);
        var typeOrder = typeOrderService.GetAllType();

        StatusOrderService statusOrderService = new StatusOrderService();
        statusOrderService.Initialize(statusOrderService);
        var statusOrder = statusOrderService.GetAllStatus();

        int count = 0;

        ShowOrdersTop();

        foreach (var order in Orders)
        {
            ShowOdrerDetails(order, typeOrder, statusOrder);
            count++;
            ShowOrderLine();
        }
        if (count == 0)
        {
            Console.WriteLine("Brak zamówień");
        }
        Console.ReadLine();
        //Todo: menu robienia
        return count;
    }
    public int ShowOrder(int id)
    {
        TypeOrderService typeOrderService = new TypeOrderService();
        typeOrderService.Initialize(typeOrderService);
        var typeOrder = typeOrderService.GetAllType();

        StatusOrderService statusOrderService = new StatusOrderService();
        statusOrderService.Initialize(statusOrderService);
        var statusOrder = statusOrderService.GetAllStatus();

        int count = 0;

        ShowOrdersTop();

        foreach (var order in Orders)
        {

            if (order.Id == id)
            {
                ShowOdrerDetails(order, typeOrder, statusOrder);
                count++;
                ShowOrderLine();
            }
        }
        if (count == 0)
        {
            Console.WriteLine("Brak zamówień zgodnych ze specyfikacją");
        }
        return count;
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
        int toChange = ShowOrder(idChange);
        Console.WriteLine();

        int count = 0;

        if (toChange != 0)
        {
            Console.WriteLine("Status zamówienia: ");
            StatusOrderService statusOrderService = new StatusOrderService();
            statusOrderService.Initialize(statusOrderService);
            var status = statusOrderService.GetAllStatus();
            var operationAccepted = new byte[status.Count];
            for (int i = 0; i < status.Count; i++)
            {
                Console.WriteLine($"{status[i].Id}. {status[i].Name}");
                operationAccepted[i] = (byte)status[i].Id;
            }
            byte statusNew = Validation.GiveMeByte("Dokonaj wyboru: ", operationAccepted);

            //Rozwiązanie 1 - nie działa
            foreach (var item in Orders)
            {
                if (item.Id == idChange)
                {
                    item.StatusId = statusNew;
                }
            }

            //Rozwiązanie 2 - nie działa
            //Orders.Single(o => o.Id == idChange).StatusId = statusNew;

            //Rozwiązanie 3 - nie działa
            //Order obj = Orders.FirstOrDefault(x => x.Id == idChange);
            //if (obj != null)
            //{
            //    obj.StatusId = statusNew;
            //}

            //rozwiązanie 4 - nie działa
            //Orders.Where(x => x.Id == idChange).Select(o => { o.StatusId = statusNew; return o; }).ToList();

            ShowOrder(idChange);
        }
        else
        {
            Console.WriteLine($"Podany id {idChange} zamówienia nie istnieje");
        }
        Console.ReadKey();
        return count;
    }

}