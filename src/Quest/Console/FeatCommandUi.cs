using System;
using static System.Console;

namespace Quest.Console
{
    public static class FeatCommandUi
    {
        public static void ShowError(string errorMessage)
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine(errorMessage);
            ResetColor();
        }
    }
}
