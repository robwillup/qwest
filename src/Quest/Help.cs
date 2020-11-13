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
            System.Console.WriteLine(HelpMessages.CommandHelpMessage);
        }
    }
}
