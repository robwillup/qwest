using System;
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
            await FileHandler.CreateTodoFile();
            string command = GetCommand(args);
            if (command == "do")                
                DoHandler.Add(DoHandler.Handle(args));
            else if (command == "done")
                DoneHandler.HandleDone(args);
            else if (command == "todo")
                ToDoHandler.List();
            else if (command == "undo")
                UndoHandler.Undo(args);
            else if (command == "dont")
                DontHandler.Remove(args);
            else if (args[0] == "version")
                Console.WriteLine("1.0.0");
            else if (args[0] == "help")
                HelpHandler.HandleHelp(args);
            else
                Console.WriteLine($"Command \"{args[0]}\" is undefined.");

            return 0;
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
