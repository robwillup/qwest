using System;
using System.Linq;

namespace Quest
{
    public static class ArgumentsHandler
    {
        public static bool Handle(string[] args)
        {
            if (!AnyArgument(args))
            {
                Help.SuggestHelp();
                return false;
            }            
            string command = GetCommand(args);
            if (command == "do")
                DoHandler.Add(DoHandler.Handle(args));
            else if (command == "done")
            {
                if (args.Length == 2)
                    ToDo.Complete(args[1]);
                else
                    ToDo.ListDone();
            }
            else if (args[0] == "todo")
                ToDo.List();
            else if (args[0] == "dont")
                ToDo.Delete(args[1]);
            else if (args[0] == "undo")
                UndoHandler.Undo(args[1]);
            else if (args[0] == "dont")
                DontHandler.Remove(args[1]);
            else if (args[0] == "version")
                Console.WriteLine("1.0.0");
            else if (args[0] == "help")
                Help.HandleHelp(args);
            else
                Console.WriteLine($"Command \"{args[0]}\" is undefined.");

            return true;
        }
        public static bool AnyArgument(string[] args)
        {
            return args.Length > 0;
        }
        public static string GetCommand(string[] args)
        {            
            return args[0];
        }
        public static bool HasFlag(string[] args, string flag) 
        {            
            foreach (string arg in args)
            {
                if (arg == flag)
                    return true;
            }           
            return false;
        }
        public static int GetIndexOfFlag(string[] args, string flag)
        {            
            return args.ToList().IndexOf(flag);
        }
    }
}
