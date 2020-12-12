using static System.Console;
namespace Quest
{
    public static class Help
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
