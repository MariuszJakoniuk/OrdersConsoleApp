namespace OrdersConsole.Domain.Entity;
public class MenuAction : BaseEntity
{
    public string Name { get; set; }
    public bool EmptyList { get; set; }
    public string MenuName { get; set; }

    public MenuAction(byte id, string name, bool emptyList, string menuName)
    {
        Id = id;
        Name = name;
        EmptyList = emptyList;
        MenuName = menuName;
    }
}
