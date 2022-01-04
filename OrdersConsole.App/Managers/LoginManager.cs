namespace OrdersConsole.App.Managers;

public class LoginManager
{
    private IServiceLogin<UserOrder> _loginService;

    public LoginManager(IServiceLogin<UserOrder> userService)
    {
        _loginService = userService;
        LoginUser();
    }

    public void LoginUser()
    {
        if (!_loginService.LoadAllUser())
        {
            Console.WriteLine("Brak uzytkowników");
            CreateUser();
            return;
        }
        else
        {
            CheckUser();
        }
    }

    public bool CreateUser()
    {
        if (Validation.GiveMeChar("Czy utworzyć urzytkownika? (T)ak/(N)ie: ", new char[] { 'T', 'N' }) != "T")
        {
            return false;
        }
        UserOrder userAdd = new UserOrder();
        userAdd.UserName = Validation.GiveMeString("Podaj nazwę uzytkownika: ");
        userAdd.Password = _loginService.PasswordCode(Validation.GiveMeString("Podaj hasło: "));
        _loginService.AddUser(userAdd);
        _loginService.SaveAllUser();
        if (StaticData.UserName == "")
        {
            StaticData.UserName = userAdd.UserName;
        }
        return true;
    }
    public bool CheckUser()
    {
        UserOrder userLogin = new UserOrder();
        userLogin.UserName = Validation.GiveMeString("Podaj nazwę uzytkownika: ");
        userLogin.Password = _loginService.PasswordCode(Validation.GiveMeString("Podaj hasło: "));
        bool check = _loginService.PaswoodCheck(userLogin.UserName, userLogin.Password);
        if (check)
        {
            StaticData.UserName = userLogin.UserName;
        }
        return check;
    }

    public bool DeleteUser()
    {
        return _loginService.DeleteUser(Validation.GiveMeString("Podaj nazwę uzytkownika: "));
    }

    private bool PasswordChangeUser()
    {
        UserOrder userLogin = new UserOrder();
        userLogin.UserName = Validation.GiveMeString("Podaj nazwę uzytkownika: ");
        userLogin.Password = _loginService.PasswordCode(Validation.GiveMeString("Podaj nowe hasło: "));
        bool check = _loginService.UpdateUser(userLogin);
        return check;
    }

    public void AdminUser(List<MenuAction> adminMenu)
    {
        bool adminSide = true;
        do
        {
            Console.Clear();
            Console.WriteLine("Lista uzytkowników:");
            Console.WriteLine("--------------------");
            foreach (UserOrder user in _loginService.Users)
            {
                Console.WriteLine(user.UserName);
            }
            Console.WriteLine("--------------------");
            Console.WriteLine();

            byte[] operationAccepted = new byte[adminMenu.Count];
            for (byte i = 0; i < adminMenu.Count; i++)
            {
                Console.WriteLine($"{adminMenu[i].Id}. {adminMenu[i].Name}");
                operationAccepted[i] = (byte)adminMenu[i].Id;
            }
            byte operation = Validation.GiveMeByte("Dokonaj wyboru: ", operationAccepted);

            switch (operation)
            {
                case 1:
                    bool userAdd = CreateUser();
                    break;
                case 2:
                    bool userDelete = DeleteUser();
                    break;
                case 3:
                    bool userPassChange = PasswordChangeUser();
                    break;
                case 9:
                    adminSide = false;
                    break;
                default:
                    Console.Beep();
                    Console.WriteLine("Coś poszło nie tak");
                    Console.ReadKey();
                    break;
            }
        }
        while (adminSide);
    }
}