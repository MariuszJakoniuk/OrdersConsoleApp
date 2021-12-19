namespace OrdersConsoleApp;

public static class Validation
{
    public static byte GiveMeByte(string text)
    {
        byte number = 0;
        string numberText;
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

}



