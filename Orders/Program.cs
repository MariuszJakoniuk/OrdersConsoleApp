using Orders.App;
using Orders.App.Concrete;

bool appExit = false;
int countOrder = 0;

MenuActionService actionService = new MenuActionService();
OrderService orderService = new OrderService();

Console.WriteLine("Witam w systemie do obsługi zamówień.");
Console.WriteLine();


do
{
    countOrder = orderService.ShowOrder();
    Console.WriteLine("Prosze wybrać operację do wykonania:");
    var menuTop = actionService.GetMenu("TopMenu");
    byte[] operationAccepted = new byte[menuTop.Count];
    for (byte i = 0; i < menuTop.Count; i++)
    {
        if (menuTop[i].EmptyList == true)
        {
            Console.WriteLine($"{menuTop[i].Id}. {menuTop[i].Name}");
            operationAccepted[i] = (byte)menuTop[i].Id;
        }
        else if (countOrder > 0)
        {
            Console.WriteLine($"{menuTop[i].Id}. {menuTop[i].Name}");
            operationAccepted[i] = (byte)menuTop[i].Id;
        }
    }
    byte operation = Validation.GiveMeByte("Dokonaj wyboru: ", operationAccepted);

    switch (operation)
    {
        case 1:
            int idAdd = orderService.AddNewOrders();
            break;
        case 2:
            int idDetails = Validation.GiveMeInt("Podaj Id zamówienia: ");
            int countDetalis = orderService.ShowOrder(idDetails);
            break;
        case 3:
            int idChange = Validation.GiveMeInt("Podaj Id zamówienia: ");
            int countChange = orderService.OrderStatusChange(idChange);
            break;
        case 4:
            int idRemove = Validation.GiveMeInt("Podaj Id zamówienia: ");
            int countRemove = orderService.RemoveOrder(idRemove);
            break;
        case 5:
            int idEdit = Validation.GiveMeInt("Podaj numer zamówienia: ");
            int countEdit = orderService.EditOrder(idEdit);
            break;
        case 9:
            appExit = true;
            break;
        default:
            Console.Beep();
            Console.WriteLine("Coś poszło nie tak");
            Console.ReadKey();
            break;
    }
    Console.Clear();
}
while (!appExit);