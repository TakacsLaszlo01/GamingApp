using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingConsoleApplication;

internal static class Utils
{
    public static string Input(string text, int minInputLength = 1)
    {
        Console.Write(text);
        string input;
        do
        {
            input = Console.ReadLine();
        } while (input == null || input.Length < minInputLength);
        return input;
    }
}
