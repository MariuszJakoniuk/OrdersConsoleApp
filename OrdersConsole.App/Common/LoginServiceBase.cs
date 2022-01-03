namespace OrdersConsole.App.Common;
public class LoginServiceBase<T> : IServiceLogin<T> where T : UserOrder
{
    public List<T> Users { get; set; }

    private const int KEYSIZE = 256;
    private byte[] salt = Encoding.UTF8.GetBytes("salt");
    private byte[] iv = Encoding.UTF8.GetBytes("1234567890123456");
    string directoryData = $@"{StaticData.DataFolder}Data\";
    string file = $@"{StaticData.DataFolder}Data\Users.txt";

    public LoginServiceBase()
    {
        Users = new List<T>();
    }

    public List<T> GetAllUsers(T user)
    {
        return Users;
    }

    public bool AddUser(T user)
    {
        if (user == null)
        {
            return false;
        }
        user.CreatedById = StaticData.UserName;
        user.CreatedDateTime = DateTime.Now;
        Users.Add(user);
        return true;
    }

    public bool DeleteUser(string userName)
    {
        T? user = GetUserByID(userName);
        if (user == null)
        {
            return false;
        }
        Users.Remove(user);
        return true;
    }

    public void EditModifedItems(T user)
    {
        user.ModifiedById = StaticData.UserName;
        user.ModifiedDateTime = DateTime.Now;
        throw new NotImplementedException();
    }

    public T? GetUserByID(string userName)
    {
        T? user = Users.FirstOrDefault(p => p.UserName == userName);
        return user;
    }

    public bool LoadAllUser()
    {
        if (!File.Exists(file))
        {
            return false;
        }

        Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
        using StreamReader sr = new StreamReader(file);
        using JsonReader reader = new JsonTextReader(sr);

        var test = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(file));

        if (test == null)
        {
            return false;
        }

        Users.AddRange(test);

        return true;
    }

    public string PasswordCode(string password, string userName)
    {
        using var rij = new RijndaelManaged()
        {
            KeySize = KEYSIZE,
            Mode = CipherMode.CBC,
            Padding = PaddingMode.PKCS7
        };

        using var rfc = new Rfc2898DeriveBytes(password, salt);
        rij.Key = rfc.GetBytes(KEYSIZE / 8);
        rij.IV = iv;

        using var ms = new MemoryStream();
        using var cs = new CryptoStream(ms, rij.CreateEncryptor(), CryptoStreamMode.Write);

        using (var bw = new BinaryWriter(cs))
        {
            bw.Write(Encoding.UTF8.GetBytes(userName));
        }

        return Encoding.UTF8.GetString(ms.ToArray());
    }

    public bool PaswoodCheck(string userName, string password)
    {
        UserOrder? user = new UserOrder();
        user = Users.FirstOrDefault(x => x.UserName == userName);
        if (user == null)
        {
            return false;
        }

        if (password != user.Password)
        {
            return false;
        }
        return true;
    }

    public bool SaveAllUser()
    {
        if (!Directory.Exists(directoryData))
        {
            Directory.CreateDirectory(directoryData);
        }
        if (File.Exists(file))
        {
            File.Delete(file);
        }

        using StreamWriter sw = new StreamWriter(file);
        using JsonWriter writer = new JsonTextWriter(sw);
        JsonSerializer serializer = new JsonSerializer();
        serializer.Serialize(writer, Users);

        return true;
    }

    public bool UpdateUser(T user)
    {
        UserOrder? userUpdate = Users.FirstOrDefault(x => x.UserName == user.UserName);
        if (userUpdate == null)
        {
            return false;
        }
        userUpdate.Password = user.Password;
        userUpdate.ModifiedById = StaticData.UserName;
        userUpdate.ModifiedDateTime = DateTime.Now;
        SaveAllUser();
        return true;
    }
}
