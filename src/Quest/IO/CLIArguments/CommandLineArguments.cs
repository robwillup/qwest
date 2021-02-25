using System;
using System.Linq;

namespace Quest.IO.CLIArguments
{
    static class CommandLineArguments
    {
        public static bool AnyArgument(string[] args) => args.Length > 0;        
        public static bool HasFlag(string[] args, string flag) => args.Contains(flag);

        public static string GetCommand(string[] args) 
        {
            return args[0] == "done" && (args.Length == 1 || args.Length == 5) ? "list-done" : args[0];
        }
        public static int GetIndexOfFlag(string[] args, string flag)
        {
            if (!HasFlag(args, flag))
                throw new ArgumentException("Missing one or more required arguments. \n Run 'quest help [command]' for more information.");
            return args.ToList().IndexOf(flag);
        }

        public static bool IsArgumentValid(string[] args, params int[] argumentIndexes)
        {            
            foreach (int index in argumentIndexes)
            {
                if (string.IsNullOrEmpty(args[index]))
                    return false;
                if (string.IsNullOrWhiteSpace(args[index]))
                    return false;
            }
            return true;
        }
        
        public static string GetAliasOrArgument(string[] args, string arg, string alias)
        {
            if (args.Contains(arg))
                return arg;
            if (args.Contains(alias))
                return alias;
            throw new ArgumentException("Missing one or more required arguments. \n Run 'quest help [command]' for more information.");
        }
    }
}
