﻿namespace OrdersConsoleApp;

public class MenuAction
{
    public MenuAction(int id, string name, string menuName)
    {
        Id = id;
        Name = name;
        MenuName = menuName;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string MenuName { get; set; }
}
