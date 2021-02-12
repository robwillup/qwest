using Quest.IO;
using Quest.Models;
using Quest.ObjectParsers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Quest.Commands
{
    public static class DontHandler
    {
        public static bool Handle(string[] args)
        {
            try
            {
                int dontTextIndex = CommandLineArguments.GetIndexOfFlag(args, "dont") + 1;
                if (!CommandLineArguments.IsArgumentValid(args, dontTextIndex))
                    throw new ArgumentException("Missing one or more required arguments. \n Run 'quest help [command]' for more information.");
                string dontText = args[dontTextIndex];                
                App app = AppParser.GetAppFromCommandLineArguments(args);
                string todoPath = Path.Combine(app.LocalPath, ".quest", app.Features.First().Name, "todo.md");
                return Remove(dontText, todoPath);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool Remove(string dontText, string todoPath)
        {
            try
            {
                List<string> todoContent = File.ReadAllLines(todoPath).ToList();
                if (todoContent.Count == 0)
                    throw new ArgumentException("No active tasks found");

                todoContent.Remove(todoContent.FirstOrDefault(t => t.Contains(dontText)));
                File.WriteAllLines(todoPath, todoContent);
                return true;
            }
            catch (ArgumentException)
            {
                throw;
            }
        }
    }
}
