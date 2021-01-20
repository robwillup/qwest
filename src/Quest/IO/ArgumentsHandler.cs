using System.Linq;
using System.Threading.Tasks;
using Quest.Commands;

namespace Quest
{
    public static class ArgumentsHandler
    {
        public static async Task<int> Handle(string[] args)
        {
            if (!AnyArgument(args))
            {
                HelpHandler.SuggestHelp();
                return 1;
            }
            await FileHandler.CreateTodoFileAsync();
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
