using Quest.IO;
using Quest.Models;
using Quest.ObjectParsers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Console;

namespace Quest.Commands
{
    public static class DontHandler
    {
        public static int HandleDont(string[] args)
        {
            try
            {
                int dontTextIndex = CommandLineArguments.GetIndexOfFlag(args, "dont") + 1;
                if (CommandLineArguments.IsArgumentValid(args, dontTextIndex))
                    throw new ArgumentException("Missing one or more required arguments. \n Run 'quest help [command]' for more information.");
                string dontText = args[dontTextIndex];                
                App app = AppParser.GetAppFromCommandLineArguments(args);
                return Remove(dontText, app);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int Remove(string dontText, App app)
        {            
            string todoPath = Path.Combine(app.LocalPath, ".quest", app.Features.First().Name, "todo.md");
            List<string> todoContent = File.ReadAllLines(todoPath).ToList();
            if (todoContent.Count == 0)
            {
                WriteLine("No active tasks found.");
                return 1;
            }
            todoContent.Remove(todoContent.FirstOrDefault(t => t.Contains(dontText)));
            File.WriteAllLines(todoPath, todoContent);
            return 0;
        }
    }
}
