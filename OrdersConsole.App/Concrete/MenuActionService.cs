namespace OrdersConsole.App.Concrete;
public class MenuActionService : BaseService<MenuAction>
{
    public MenuActionService()
    {
        Initialize();
    }

    public void Initialize()
    {
        AddItem(new MenuAction(1, "Dodaj zamówienie", true, "TopMenu"));
        AddItem(new MenuAction(2, "Zmień status zamówienia", false, "TopMenu"));
        AddItem(new MenuAction(3, "Edytuj zamówienie", false, "TopMenu"));
        AddItem(new MenuAction(4, "Usuń zamówienie", false, "TopMenu"));
        AddItem(new MenuAction(8, "Użytkownicy", true, "TopMenu"));
        AddItem(new MenuAction(9, "Zakończ program", true, "TopMenu"));
        
        AddItem(new MenuAction(1, "Dodaj użytkownika", true, "AdminUser"));
        AddItem(new MenuAction(2, "Usuń użytkownika", true, "AdminUser"));
        AddItem(new MenuAction(3, "Zmień hasło", true, "AdminUser"));
        AddItem(new MenuAction(9, "Wyjdz z Administracji uzytkownikami", true, "AdminUser"));
    }

    public List<MenuAction> GetMenu(string menuName)
    {
        List<MenuAction> result = new List<MenuAction>();
        foreach (MenuAction menuAction in Items)
        {
            if (menuAction.MenuName == menuName)
            {
                result.Add(menuAction);
            }
        }
        return result;
    }
    
    public List<MenuAction> GetMenu(string menuName, bool emptyList)
    {
        List<MenuAction> result = new List<MenuAction>();
        foreach (MenuAction menuAction in Items)
        {
            if (menuAction.MenuName == menuName && menuAction.EmptyList == emptyList)
            {
                result.Add(menuAction);
            }
        }
        return result;
    }
}
