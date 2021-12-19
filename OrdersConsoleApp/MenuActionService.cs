namespace OrdersConsoleApp;

public class MenuActionService
{
    private List<MenuAction> menuActions;

    public MenuActionService()
    {
        menuActions = new List<MenuAction>();
    }

    public static MenuActionService Initialize(MenuActionService actionService)
    {
        actionService.AddNewAction(0, "Lista zamówień", true, "");
        actionService.AddNewAction(1, "Dodaj zamówienie", true, "");
        actionService.AddNewAction(2, "Wyświetl zamówienie", true, "");
        actionService.AddNewAction(3, "Zmień status zamówienia", true, "");
        actionService.AddNewAction(4, "Usuń zamówienie", true, "");
        actionService.AddNewAction(9, "Zakończ program", true, "");

        return actionService;
    }

    public void AddNewAction(int id, string name, bool menuTop, string menuName )
    {
        MenuAction menuAction = new MenuAction(id, name, menuTop, menuName);
        menuActions.Add(menuAction);
    }

    public List<MenuAction> GetMenuTop()
    {
        List<MenuAction> result = new List<MenuAction>();
        foreach (MenuAction menuAction in menuActions)
        {
            if (menuAction.MenuTop == true)
            {
                result.Add(menuAction);
            }
        }
        return result;
    }
}
