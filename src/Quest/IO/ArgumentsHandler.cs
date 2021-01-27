using System.Linq;
using Quest.Data.Help;
using Quest.IO;

namespace Quest
{
    public static class ArgumentsHandler
    {
        public static int Handle(string[] args)
        {
            if (!AnyArgument(args))
                return Help.WriteHelpMessage(HelpMessageTypes.Suggestion);            
            string command = GetCommand(args);
            return CommandSelector.Run(args, command);
        }

        public static bool AnyArgument(string[] args) => args.Length > 0;
        public static string GetCommand(string[] args) => args[0];
        public static bool HasFlag(string[] args, string flag)
        {
            foreach (string arg in args)
            {
                if (arg == flag)
                    return true;
            }           
            return false;
        }
        public static int GetIndexOfFlag(string[] args, string flag) => args.ToList().IndexOf(flag);
    }
}
