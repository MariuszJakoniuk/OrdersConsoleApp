namespace OrdersConsole.App.Abstract;

public interface IServiceLogin<T> where T : class
{
    List<T> Users { get; set; }

    bool LoadAllUser();
    List<T> GetAllUsers(T user);
    T? GetUserByID(string userName);
    bool PaswoodCheck(string userName, string password);
    string PasswordCode(string password);
    void EditModifedItems(T user);
    bool AddUser(T user);
    bool UpdateUser(T user);
    bool DeleteUser(string userName);
    bool SaveAllUser();
}

