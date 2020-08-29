namespace Quest.Commands
{
    public static class Help
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
    init
    feat
    do
    done
    todo
    undo
    redo
    dont
    help
";
            return defaultHelpMessage;
        }
    }
}
