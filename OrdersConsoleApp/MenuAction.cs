namespace OrdersConsoleApp;

public class MenuAction
{
    public MenuAction(int id, string name, bool menuTop, string menuName)
    {
        Id = id;
        Name = name;
        MenuTop = menuTop;
        MenuName = menuName;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public bool MenuTop { get; set; }
    public string MenuName { get; set; }
}
