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
            else
            {
                if (args.Length == 2)
                {
                    if (args[1] == "config")
                    {
                        WriteLine("View and edit Quest settings");
                        WriteLine("Examples:");
                        WriteLine("\tquest config list");
                        WriteLine("\tquest config add --name my-app");
                    }
                }
                else
                {
                    if (args[2] == "list")
                    {
                        WriteLine("Displays current configuration");
                        return;
                    }
                    if (args[2] == "add")
                    {
                        WriteLine("Adds new configuration section");
                        return;
                    }
                }
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
