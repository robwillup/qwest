using static System.Console;
using Quest.IO;
using Quest.Data.Help;

namespace Quest.Commands
{
    public static class HelpHandler
    {
        public static void HandleHelp(string[] args) 
        {
            if (args.Length == 1)
                Help.WriteHelpMessage(HelpMessageTypes.Default);
            else
            {
                if (args.Length == 2)
                    Help.WriteHelpMessage(SelectCommandHelp(args));
                else
                    SelectSubcommandHelp(args);
            }             
        }

        public static HelpMessageTypes SelectCommandHelp(string[] args)
        {
            if (args[1] == "config")
                return HelpMessageTypes.Configuration;
            else if (args[1] == "do")
                return HelpMessageTypes.Do;
            else if (args[1] == "done")
                return HelpMessageTypes.Done;
            return HelpMessageTypes.Default;
        }

        public static void SelectSubcommandHelp(string[] args)
        {
            if (args[2] == "list")
                WriteLine("Displays current configuration");
            if (args[2] == "add")
                WriteLine("Adds new configuration section");
            if (args[2] == "rm")
                WriteLine("Removes a configuration section");
        }
    }
}
