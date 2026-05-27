using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingConsoleApplication;

internal static class Utils
{
    public static readonly Dictionary<int, int> DaysPerMonth = new()
    {
        {1, 31}, {2, 29}, {3, 31}, {4, 30},
        {5, 31}, {6, 30}, {7, 31}, {8, 31},
        {9, 30}, {10, 31}, {11, 30}, {12, 31}
    };
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
