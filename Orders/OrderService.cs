namespace Orders;
public class OrderService
{
    public List<Order> Orders { get; set; }
    private List<TypeOrder> TypeOrders { get; init; }
    private List<StatusOrder> StatusOrders { get; set; }

    public OrderService()
    {
        Orders = new List<Order>();
        TypeOrders = new List<TypeOrder>();
        StatusOrders = new List<StatusOrder>();
        TypeRead();
        StatusReader();
    }

    private void TypeRead()
    {
        TypeOrderService typeOrderService = new TypeOrderService();
        typeOrderService.Initialize(typeOrderService);
        TypeOrders.AddRange(typeOrderService.GetAllType());
    }

    private void StatusReader()
    {
        StatusOrderService statusOrderService = new StatusOrderService();
        statusOrderService.Initialize(statusOrderService);
        StatusOrders.AddRange(statusOrderService.GetAllStatus());
    }

    public int AddNewOrders()
    {
        Console.Clear();
        Console.WriteLine("Wybiez typ zamówienia: ");

        byte[] operationAccepted = new byte[TypeOrders.Count];
        for (int i = 0; i < TypeOrders.Count; i++)
        {
            Console.WriteLine($"{TypeOrders[i].Id}. {TypeOrders[i].Name}");
            operationAccepted[i] = (byte)TypeOrders[i].Id;
        }
        byte operation = Validation.GiveMeByte("Dokonaj wyboru: ", operationAccepted);

        Order order = new Order();
        order.TypeId = operation;
        order.Id = Validation.GiveMeInt("Podaj Id zamówienia: ");
        order.Name = Validation.GiveMeString("Podaj nazwe zamówienia: ");
        order.OrderDate = DateTime.Now;

        Console.WriteLine("Status zamówienia: ");
        operationAccepted = new byte[StatusOrders.Count];
        for (int i = 0; i < StatusOrders.Count; i++)
        {
            Console.WriteLine($"{StatusOrders[i].Id}. {StatusOrders[i].Name}");
            operationAccepted[i] = (byte)StatusOrders[i].Id;
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

    private void ShowOdrerDetails(Order order)
    {
        string? text;
        Console.Write("|");
        text = ("   " + order.Id).Substring(("   " + order.Id).Length - 3, 3);
        Console.Write(text);
        Console.Write("|");
        text = $"{TypeOrders.FirstOrDefault(x => x.Id == order.TypeId).Name}         ".Substring(0, 8);
        Console.Write(text);
        Console.Write("|");
        text = (order.Name + "                              ").Substring(0, 29);
        Console.Write(text);
        Console.Write("|");
        text = order.OrderDate.ToShortDateString();
        Console.Write(text);
        Console.Write("|");
        text = $"{StatusOrders.FirstOrDefault(x => x.Id == order.StatusId).Name}              ".Substring(0, 12);
        Console.Write(text);
        Console.Write("|");
        text = order.Dedline == null ? "          " : ((DateTime)order.Dedline).ToShortDateString();
        Console.Write(text);
        Console.WriteLine("|");
    }

    public int ShowOrder(List<MenuAction> menuActions)
    {
        int count = 0;

        ShowOrdersTop();

        foreach (var order in Orders)
        {
            ShowOdrerDetails(order);
            count++;
            ShowOrderLine();
        }
        if (count == 0)
        {
            Console.WriteLine("Brak zamówień");
        }
        Console.WriteLine();
        if (count > 0)
        {
            byte[] operationAccepted = new byte[menuActions.Count];
            for (int i = 0; i < menuActions.Count; i++)
            {
                Console.WriteLine($"{menuActions[i].Id}. {menuActions[i].Name}");
                operationAccepted[i] = menuActions[i].Id;
            }
            byte operation = Validation.GiveMeByte("Dokonaj wyboru: ", operationAccepted);

            switch (operation)
            {
                case 1:
                    int idAdd = AddNewOrders();
                    break;
                case 3:
                    int idChange = Validation.GiveMeInt("Podaj numer zamówienia: ");
                    int countChange = OrderStatusChange(idChange);
                    break;
                case 4:
                    int idRemove = Validation.GiveMeInt("Podaj numer zamówienia: ");
                    int countRemove = RemoveOrder(idRemove);
                    break;
                case 5:
                    int idEdit = Validation.GiveMeInt("Podaj numer zamówienia: ");
                    int countEdit = EditOrder(idEdit);
                    break;
                default:
                    Console.Beep();
                    Console.WriteLine("Coś poszło nie tak");
                    Console.ReadKey();
                    break;
            }
        }
        else
        {
            Console.ReadKey();
        }
        return count;
    }

    public int ShowOrder(int id)
    {
        Order? order = Orders.FirstOrDefault(x => x.Id == id);

        if (order != null)
        {
            ShowOrdersTop();
            ShowOdrerDetails(order);
            ShowOrderLine();
            return 1;
        }
        else
        {
            Console.WriteLine("Brak zamówień zgodnych ze specyfikacją");
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
        int toChange = ShowOrder(idChange);
        Console.WriteLine();

        int count = 0;

        if (toChange != 0)
        {
            var operationAccepted = new byte[StatusOrders.Count];
            for (int i = 0; i < StatusOrders.Count; i++)
            {
                Console.WriteLine($"{StatusOrders[i].Id}. {StatusOrders[i].Name}");
                operationAccepted[i] = (byte)StatusOrders[i].Id;
            }
            byte statusNew = Validation.GiveMeByte("Dokonaj wyboru: ", operationAccepted);

            Orders.FirstOrDefault(x => x.Id == idChange).StatusId = statusNew;
            count++;
            ShowOrder(idChange);
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
                Orders.Remove(Orders.FirstOrDefault(x => x.Id == idRemove));
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
        int toEdit = ShowOrder(idEdit);
        Console.WriteLine();

        int count = 0;

        if (toEdit != 0)
        {
            if (Validation.GiveMeChar("Czy zmienić typ zamówienia? (T)ak/(N)ie: ", new char[] { 'T', 'N' }) == "T")
            {
                var operationAccepted = new byte[TypeOrders.Count];
                for (int i = 0; i < TypeOrders.Count; i++)
                {
                    Console.WriteLine($"{TypeOrders[i].Id}. {TypeOrders[i].Name}");
                    operationAccepted[i] = (byte)TypeOrders[i].Id;
                }
                byte typeNew = Validation.GiveMeByte("Dokonaj wyboru: ", operationAccepted);
                Orders.FirstOrDefault(x => x.Id == idEdit).TypeId = typeNew;
                count++;
            }
            if (Validation.GiveMeChar("Czy zmienić nazwę zamówienia? (T)ak/(N)ie: ", new char[] { 'T', 'N' }) == "T")
            {
                Orders.FirstOrDefault(x => x.Id == idEdit).Name = Validation.GiveMeString("Nowa nazwa zamówienia: ");
                count++;
            }
            if (Validation.GiveMeChar("Czy zmienić datę wpłyniecia zamówienia? (T)ak/(N)ie: ", new char[] { 'T', 'N' }) == "T")
            {
                Orders.FirstOrDefault(x => x.Id == idEdit).OrderDate = Validation.GiveMeDate();
                count++;
            }
            if (Validation.GiveMeChar("Czy zmienić status zamówienia? (T)ak/(N)ie: ", new char[] { 'T', 'N' }) == "T")
            {
                var operationAccepted = new byte[StatusOrders.Count];
                for (int i = 0; i < StatusOrders.Count; i++)
                {
                    Console.WriteLine($"{StatusOrders[i].Id}. {StatusOrders[i].Name}");
                    operationAccepted[i] = (byte)StatusOrders[i].Id;
                }
                byte statusNew = Validation.GiveMeByte("Dokonaj wyboru: ", operationAccepted);

                Orders.FirstOrDefault(x => x.Id == idEdit).StatusId = statusNew;
                count++;
            }
            if (Validation.GiveMeChar("Czy zmienić datę realizacji zamówienia? (T)ak/(N)ie: ", new char[] { 'T', 'N' }) == "T")
            {
                Orders.FirstOrDefault(x => x.Id == idEdit).Dedline = Validation.GiveMeDate();
                count++;
            }
            ShowOrder(idEdit);
        }
        else
        {
            Console.WriteLine($"Podany id {idEdit} zamówienia nie istnieje");
        }
        Console.WriteLine("\n\rNaciśnij klawisz by wyjść.");
        Console.ReadKey();
        return count;
    }
}