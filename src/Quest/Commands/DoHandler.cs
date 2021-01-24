using System;
using static System.Console;
using System.IO;
using System.Collections.Generic;
using Quest.Models;
using System.Linq;

namespace Quest.Commands
{
    public static class DoHandler
    {
        public static int Add(QuestTask todo)
        {
            Config config = Setup.GetConfig();
            string appPath = config.Applications.FirstOrDefault(e => e.Name == todo.AppName).LocalPath;
            // create local .quest dir
            Directory.CreateDirectory(Path.Combine(appPath, ".quest"));
            string todoPath = Path.Combine(appPath, ".quest", todo.FeatureName, "todo.md");
            string todoText = $"* {todo.Name} - ({todo.Id}) - Created at: {DateTime.Now}";
            List<string> lines = new List<string>() { todoText};
            string dir = Path.GetDirectoryName(todoPath);
            Directory.CreateDirectory(dir);
            Console.WriteLine(dir);
            Console.WriteLine(todoPath);
            File.AppendAllLines(todoPath, lines);
            return 0;
        }

        public static QuestTask Handle(string[] args)
        {
            if (args.Length < 6)
                throw new ArgumentException("Missing one or more required arguments. \n Run 'quest help [command]' for more information.");
            if (!ArgumentsHandler.HasFlag(args, "--app") || !ArgumentsHandler.HasFlag(args, "--feature"))
                throw new ArgumentException("Missing one or more required arguments. \n Run 'quest help [command]' for more information.");

            int doIndex = ArgumentsHandler.GetIndexOfFlag(args, "do") + 1;
            int appIndex = ArgumentsHandler.GetIndexOfFlag(args, "--app") + 1;
            int featureIndex = ArgumentsHandler.GetIndexOfFlag(args, "--feature") + 1;

            if (string.IsNullOrEmpty(args[doIndex]) || string.IsNullOrEmpty(args[appIndex]) || string.IsNullOrEmpty(args[featureIndex]))
                throw new ArgumentException("Missing one or more required arguments. \n Run 'quest help [command]' for more information.");
            if (string.IsNullOrWhiteSpace(args[doIndex]) || string.IsNullOrWhiteSpace(args[appIndex]) || string.IsNullOrWhiteSpace(args[featureIndex]))
                throw new ArgumentException("Missing one or more required arguments. \n Run 'quest help [command]' for more information.");

            return new QuestTask()
            {
                Name = args[doIndex],
                AppName = args[appIndex],
                FeatureName = args[featureIndex]
            };
        }
    }
}
