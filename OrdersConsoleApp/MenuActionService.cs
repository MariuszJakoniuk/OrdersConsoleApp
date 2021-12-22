namespace OrdersConsoleApp;

public class MenuActionService
{
    private List<MenuAction> menuActions;

    public MenuActionService()
    {
        menuActions = new List<MenuAction>();
    }

    public MenuActionService Initialize(MenuActionService actionService)
    {
        actionService.AddNewAction(0, "Lista zamówień", "TopMenu");
        actionService.AddNewAction(1, "Dodaj zamówienie", "TopMenu");
        actionService.AddNewAction(2, "Wyświetl zamówienie", "TopMenu");
        actionService.AddNewAction(3, "Zmień status zamówienia", "TopMenu");
        actionService.AddNewAction(4, "Usuń zamówienie", "TopMenu");
        actionService.AddNewAction(9, "Zakończ program", "TopMenu");

        return actionService;
    }

    public void AddNewAction(int id, string name, string menuName)
    {
        MenuAction menuAction = new MenuAction(id, name, menuName);
        menuActions.Add(menuAction);
    }

    public List<MenuAction> GetMenuTop()
    {
        //List<MenuAction> result = new List<MenuAction>();
        //foreach (MenuAction menuAction in menuActions)
        //{
        //    if (menuAction.MenuName == "TopMenu")
        //    {
        //        result.Add(menuAction);
        //    }
        //}
        return menuActions;
    }
}
