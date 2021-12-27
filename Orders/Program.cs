using Orders.App;
using Orders.App.Concrete;
using Orders.App.Managers;

bool appExit = false;
int countOrder = 0;

MenuActionService actionService = new MenuActionService();
OrderService orderService = new OrderService();
OrderManager orderMenager = new OrderManager(orderService);

Console.WriteLine("Witam w systemie do obsługi zamówień.");
Console.WriteLine();

do
{
    countOrder = orderMenager.ShowOrder();
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
            int idAdd = orderMenager.AddNewOrders();
            break;
        case 2:
            int idChange = Validation.GiveMeInt("Podaj Id zamówienia: ");
            int countChange = orderMenager.OrderStatusChange(idChange);
            break;
        case 3:
            int idEdit = Validation.GiveMeInt("Podaj numer zamówienia: ");
            int countEdit = orderMenager.EditOrder(idEdit);
            break;
        case 4:
            int idRemove = Validation.GiveMeInt("Podaj Id zamówienia: ");
            int countRemove = orderMenager.RemoveOrder(idRemove);
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