using Quest.Data.Help;
using Quest.IO;

namespace Quest.Commands
{
    public static class Help
    {
        public static void HandleHelp(string[] args) 
        {
            if (args.Length == 1)
                HelpDisplayer.WriteHelpMessage(HelpMessageTypes.Default);
            else
            {
                if (args.Length == 2)
                    HelpDisplayer.WriteHelpMessage(SelectCommandHelp(args));
                else
                    HelpDisplayer.WriteHelpMessage(SelectSubcommandHelp(args));
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
            else if (args[1] == "todo")
                return HelpMessageTypes.Todo;
            else if (args[1] == "undo")
                return HelpMessageTypes.Undo;
            else if (args[1] == "dont")
                return HelpMessageTypes.Dont;
            return HelpMessageTypes.Default;
        }

        public static HelpMessageTypes SelectSubcommandHelp(string[] args)
        {
            if (args[1] == "config")
            {
                if (args[2] == "list")
                    return HelpMessageTypes.ConfigList;                
                if (args[2] == "add")
                    return HelpMessageTypes.ConfigAdd;                    
                if (args[2] == "rm")
                    return HelpMessageTypes.ConfigRemove;
            }
            return HelpMessageTypes.Default;
        }
    }
}
