namespace OrdersConsoleApp;
public class MenuAction
{
    public MenuAction(byte id, string name, string menuName)
    {
        Id = id;
        Name = name;
        MenuName = menuName;
    }

    public byte Id { get; set; }
    public string Name { get; set; }
    public string MenuName { get; set; }
}
