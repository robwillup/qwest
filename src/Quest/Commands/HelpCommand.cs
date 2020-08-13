namespace Quest.Commands
{
    public static class HelpCommand
    {
        public static string GetHelp(string command)
        {
            switch (command)
            {
                default:
                    return GetDefaultHelpMessage();
            }            
        }

        private static string GetDefaultHelpMessage()
        {
            string defaultHelpMessage = @"Quest! The Developer To-Do App

USAGE:
    quest [COMMAND] [SUBCOMMAND]

COMMANDS:
    new
    list
    help
";
            return defaultHelpMessage;
        }
    }
}
