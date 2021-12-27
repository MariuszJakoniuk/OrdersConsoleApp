namespace Orders.App.Concrete;
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
        AddItem(new MenuAction(9, "Zakończ program", true, "TopMenu"));
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
}
