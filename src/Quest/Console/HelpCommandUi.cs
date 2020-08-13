using Quest.Commands;
using static System.Console;

namespace Quest.Console
{
    public static class HelpCommandUi
    {
        public static void GetHelp(string command)
        {
            WriteLine(HelpCommand.GetHelp("default"));
        }
    }
}
