using System;
using static System.Console;

namespace Quest.Console
{
    public static class NewCommandUi
    {
        public static void WriteNewCommandError(string message)
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine(message);
            ResetColor();
        }
    }
}
