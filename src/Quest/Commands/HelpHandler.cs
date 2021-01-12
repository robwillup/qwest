using static System.Console;
using Quest.Data;

namespace Quest.Commands
{
    public static class HelpHandler
    {
        public static void HandleHelp(string[] args) 
        {
            if (args.Length == 1)
            {
                ShowCommandHelp();
                return;
            }
            if (args[1] == "config")
            {
                WriteLine("View and edit Quest settings");
                WriteLine("Example:");
                WriteLine("\tquest config --list");
            }                
        }

        static void ShowCommandHelp() 
        {
            WriteLine(HelpMessages.CommandHelpMessage);
        }

        public static void SuggestHelp()
        {
	        WriteLine("Welcome to Quest!");
            WriteLine("Try using 'help' to see available commands.");
            WriteLine("\nExample:\n\tquest help");
        }
    }
}
