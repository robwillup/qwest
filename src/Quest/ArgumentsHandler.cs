using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Quest
{
    public static class ArgumentsHandler
    {
        public static bool Handle(string[] args)
        {
            if (!AnyArgument(args))
                return false;
            ToDo toDo = new ToDo();
            string command = GetCommand(args);
            if (command == "do")
            {
                if (!DoHandler.Handle(args))
                    toDo.Add(args[1]);
            }
            else if (command == "done")
            {
                if (args.Length == 2)
                    toDo.Complete(args[1]);
                else
                    toDo.ListDone();
            }
            else if (args[0] == "todo")
                toDo.List();
            else if (args[0] == "undo")
                toDo.Delete(args[1]);
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
