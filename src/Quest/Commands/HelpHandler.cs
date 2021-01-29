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
            {
                Help.WriteHelpMessage(HelpMessageTypes.Default);
                return;
            }
            else
            {
                if (args.Length == 2)
                {
                    if (args[1] == "config")
                        Help.WriteHelpMessage(HelpMessageTypes.Configuration);
                    else if (args[1] == "do")
                        Help.WriteHelpMessage(HelpMessageTypes.Do);
                    else if (args[1] == "done")
                        Help.WriteHelpMessage(HelpMessageTypes.Done);
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
                    if (args[2] == "rm")
                    {
                        WriteLine("Removes a configuration section");
                        return;
                    }
                }
            }             
        }
    }
}
