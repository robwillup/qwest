using System;
using System.Linq;

namespace Quest.IO
{
    static class CommandLineArguments
    {
        public static bool AnyArgument(string[] args) => args.Length > 0;
        public static string GetCommand(string[] args) => args[0];
        public static bool HasFlag(string[] args, string flag) => args.Contains(flag);
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
    }
}
