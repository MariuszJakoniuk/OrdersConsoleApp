global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Text;
global using System.Threading.Tasks;
global using Orders;

bool appExit = false;

MenuActionService actionService = new MenuActionService();
OrderService orderService = new OrderService();

actionService.Initialize(actionService);

Console.WriteLine("Witam w systemie do obsługi zamówień.");
Console.WriteLine();

do
{
    Console.WriteLine("Prosze wybrać operację do wykonania:");
    var menuTop = actionService.GetMenu("TopMenu");
    byte[] operationAccepted = new byte[menuTop.Count];
    for (int i = 0; i < menuTop.Count; i++)
    {
        Console.WriteLine($"{menuTop[i].Id}. {menuTop[i].Name}");
        operationAccepted[i] = menuTop[i].Id;
    }
    byte operation = Validation.GiveMeByte("Dokonaj wyboru: ", operationAccepted);

    switch (operation)
    {
        case 0:
            orderService.ShowOrder(actionService.GetMenu("ListMenu"));
            break;
        case 1:
            int idAdd = orderService.AddNewOrders();
            break;
        case 2:
            int idDetails = Validation.GiveMeInt("Podaj numer zamówienia: ");
            int countDetalis = orderService.ShowOrder(idDetails);
            break;
        case 3:
            int idChange = Validation.GiveMeInt("Podaj numer zamówienia: ");
            int countChange = orderService.OrderStatusChange(idChange);
            break;
        case 4:
            int idRemove = Validation.GiveMeInt("Podaj numer zamówienia: ");
            int countRemove = orderService.RemoveOrder(idRemove);
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