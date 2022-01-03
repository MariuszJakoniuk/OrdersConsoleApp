using OrdersConsole.App;
using OrdersConsole.App.Concrete;
using OrdersConsole.App.Managers;
using OrdersConsole.Domain.Entity;
using System;
using System.Collections.Generic;

bool appExit = false;
int countOrder = 0;

Console.WriteLine("Witam w systemie do obsługi zamówień.");
Console.WriteLine();

LoginService loginService = new LoginService();
LoginManager userManager = new LoginManager(loginService);

MenuActionService actionService = new MenuActionService();
OrderService orderService = new OrderService();
OrderManager orderMenager = new OrderManager(orderService);



while (!appExit && StaticData.UserName.Length > 0)
{
    countOrder = orderMenager.ShowOrder();
    Console.WriteLine("Prosze wybrać operację do wykonania:");
    List<MenuAction> menuTop;
    if (countOrder == 0)
    {
        menuTop = actionService.GetMenu(menuName: "TopMenu", emptyList: true);
    }
    else
    {
        menuTop = actionService.GetMenu(menuName: "TopMenu");
    }

    byte[] operationAccepted = new byte[menuTop.Count];
    for (byte i = 0; i < menuTop.Count; i++)
    {
        Console.WriteLine($"{menuTop[i].Id}. {menuTop[i].Name}");
        operationAccepted[i] = (byte)menuTop[i].Id;
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
        case 8:
            userManager.AdminUser(actionService.GetMenu(menuName: "AdminUser"));
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
