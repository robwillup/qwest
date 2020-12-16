using static System.Console;
using Quest.Data;

namespace Quest.Commands
{
    public static class HelpHandler
    {
        public static void HandleHelp(string[] args) 
        {
            if (args.Length == 1)
                ShowCommandHelp();
        }

        static void ShowCommandHelp() 
        {
            WriteLine(HelpMessages.CommandHelpMessage);
        }

        public static void SuggestHelp()
        {
            WriteLine("Try using 'help' to see available commands.");
            WriteLine("\nExample:\n\tquest help");
        }
    }
}
