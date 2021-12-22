global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Text;
global using System.Threading.Tasks;
global using OrdersConsoleApp;

bool appExit = false;

MenuActionService actionService = new MenuActionService();
OrderService orderService = new OrderService();

actionService.Initialize(actionService);

Console.WriteLine("Witam w systemie do obsługi zamówień.");
Console.WriteLine();

do
{
    Console.WriteLine("Prosze wybrać operację do wykonania:");
    var menuTop = actionService.GetMenuTop();
    for (int i = 0; i < menuTop.Count; i++)
    {
        Console.WriteLine($"{menuTop[i].Id}. {menuTop[i].Name}");
    }

    byte[] operationAccepted = new byte[] { 0, 1, 2, 3, 4, 9 };
    byte operation = Validation.GiveMeByte("Dokonaj wyboru: ", operationAccepted);

    switch (operation)
    {
        case 0:
            orderService.ShowOrder();
            break;
        case 1:
            int idAdd = orderService.AddNewOrders();
            break;
        case 2:
            int idDetails = Validation.GiveMeInt("Podaj numer zamówienia: ");
            orderService.ShowOrder(idDetails);
            break;
        case 3:
            int idChange = Validation.GiveMeInt("Podaj numer zamówienia: ");
            orderService.OrderStatusChange(idChange);
            break;
        case 4:
            Console.WriteLine($"Wybór: {operation}");
            break;
        case 9:
            appExit = true;
            Console.WriteLine($"Wybór: {operation}");
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