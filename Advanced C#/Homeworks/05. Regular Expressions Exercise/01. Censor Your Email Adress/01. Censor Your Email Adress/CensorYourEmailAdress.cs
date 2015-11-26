using System;
using System.Text;
class CensorYourEmailAdress
{
    static void Main()
    {
        string email = Console.ReadLine();
        string text = Console.ReadLine();
        Console.WriteLine(HideEmail(email, text));
    }

    static string HideEmail(string email, string text)
    {
        StringBuilder hiddenEmail = new StringBuilder();

        int index = email.IndexOf('@');
        for (int i = 0; i < index; i++)
        {
            hiddenEmail.Append('*');
        }
        hiddenEmail.Append(email.Substring(index));

        string newText = text.Replace(email, hiddenEmail.ToString());

        return newText;
    }

}