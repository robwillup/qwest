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
                DoHandler.Handle(args);
            else if (command == "done")
                toDo.Complete(args[1]);
            else if (args[0] == "todo")
                toDo.List();
            else if (args[0] == "undo")
                toDo.Delete(args[1]);
            else if (args[0] == "version")
                Console.WriteLine("1.0.0");
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

    public static class DoHandler
    {
        public static bool Handle(string[] args)
        {            
            int indexOfSource = 0;
            if (ArgumentsHandler.HasFlag(args, "--source")) { 
                indexOfSource = ArgumentsHandler.GetIndexOfFlag(args, "--source");}
            else if (ArgumentsHandler.HasFlag(args, "-s"))
                indexOfSource = ArgumentsHandler.GetIndexOfFlag(args, "-s");
            else
                return false;
                        
            string source = args[indexOfSource + 1];
            // USE THIS SOURCE variable to get path
            return true;
        }
    }
}
