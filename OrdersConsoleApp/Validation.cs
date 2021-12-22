namespace OrdersConsoleApp;

public static class Validation
{
    public static byte GiveMeByte(string text)
    {
        byte number = 0;
        string? numberText;
        bool isNotError = true;

        do
        {
            if (!isNotError)
            {
                Console.WriteLine("Błąd podaj jeszcze raz");
                Console.Beep();
            }

            Console.Write(text);
            numberText = Console.ReadLine();
            isNotError = byte.TryParse(numberText, out number);
        }
        while (!isNotError);

        return number;
    }

    public static byte GiveMeByte(string text, byte[] value)
    {
        byte number = 0;
        bool isNotError = true;

        do
        {
            if (!isNotError)
            {
                Console.WriteLine("Błąd podaj jeszcze raz");
                Console.Beep();
            }
            number = GiveMeByte(text);
            for (int i = 0; i < value.Length; i++)
            {
                if (value[i] == number)
                {
                    isNotError = true;
                    break;
                }
                else
                {
                    isNotError = false;
                }
            }

        }
        while (!isNotError);

        return number;
    }

    public static int GiveMeInt(string text)
    {
        int number = 0;
        string? numberText;
        bool isNotError = true;

        do
        {
            if (!isNotError)
            {
                Console.WriteLine("Błąd podaj jeszcze raz");
                Console.Beep();
            }

            Console.Write(text);
            numberText = Console.ReadLine();
            isNotError = int.TryParse(numberText, out number);
        }
        while (!isNotError);

        return number;
    }

    public static string GiveMeString(string textIn)
    {
        string? textOut;
        bool isNotError = true;

        do
        {
            if (!isNotError)
            {
                Console.WriteLine("Błąd podaj jeszcze raz");
                Console.Beep();
            }

            Console.Write(textIn);
            textOut = Console.ReadLine();
            if (textOut.Length > 0)
            {
                isNotError = true;
            }
            else
            {
                isNotError = false;
            }
        }
        while (!isNotError);

        return textOut;
    }

    public static string GiveMeChar(string textIn)
    {
        string? textOut;
        bool isNotError = true;

        do
        {
            if (!isNotError)
            {
                Console.WriteLine("Błąd podaj jeszcze raz");
                Console.Beep();
            }

            Console.Write(textIn);
            textOut = Console.ReadLine();
            if (textOut.Length == 1)
            {
                isNotError = true;
            }
            else
            {
                isNotError = false;
            }
        }
        while (!isNotError);

        return textOut;
    }
    
    public static string GiveMeChar(string textIn, char[] value)
    {
        string textOut = "";
        bool isNotError = true;

        do
        {
            if (!isNotError)
            {
                Console.WriteLine("Błąd podaj jeszcze raz");
                Console.Beep();
            }
            textOut = GiveMeChar(textIn);
            for (int i = 0; i < value.Length; i++)
            {
                if (value[i] == char.Parse(textOut.ToUpper()))
                {
                    isNotError = true;
                    break;
                }
                else
                {
                    isNotError = false;
                }
            }

        }
        while (!isNotError);

        return textOut.ToUpper();
    }

    internal static DateTime GiveMeDate()
    {
        int year;
        byte month;
        byte day;
        DateTime date;
        bool isNotError = true;
        Console.WriteLine("Podaj datę: ");
        do
        {
            if (!isNotError)
            {
                Console.WriteLine("Błąd podaj jeszcze raz");
                Console.Beep();
            }
            year = GiveMeInt("Podaj rok:");
            if (year < 2999 && year > 0)
            {
                isNotError = true;
            }
            else
            {
                isNotError = false;
            }
        }
        while (!isNotError);

        isNotError = true;
        do
        {
            if (!isNotError)
            {
                Console.WriteLine("Błąd podaj jeszcze raz");
                Console.Beep();
            }
            month = GiveMeByte("Podaj miesiąc:");
            if (month < 13 && month > 0)
            {
                isNotError = true;
            }
            else
            {
                isNotError = false;
            }
        }
        while (!isNotError);

        isNotError = true;
        do
        {
            if (!isNotError)
            {
                Console.WriteLine("Błąd podaj jeszcze raz");
                Console.Beep();
            }
            day = GiveMeByte("Podaj dzień:");
            isNotError = DateTime.TryParse($"{day}/{month}/{year}", out date);
        }
        while (!isNotError);

        return date;
    }
}