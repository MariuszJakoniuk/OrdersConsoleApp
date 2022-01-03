namespace OrdersConsole.Domain.Entity;

public class UserOrder : AuditableModel
{
    public string? UserName { get; set; }
    public string? Password { get; set; }

    public UserOrder()
    {
    }

    public UserOrder(UserOrder user)
    {
        UserName = user.UserName;
        Password = user.Password;
    }

    public UserOrder(string userName, string password)
    {
        UserName = userName;
        Password = password;
    }
}