using Quest.Models;
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
                string dontText = GetDontTextFromCommandLineArguments(args);
                App app = GetAppFromCommandLineArguments(args);
                return Remove(dontText, app);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string GetDontTextFromCommandLineArguments(string[] args)
        {
            int dontIndex = ArgumentsHandler.GetIndexOfFlag(args, "dont") + 1;
            if (string.IsNullOrEmpty(args[dontIndex]))
                throw new ArgumentException("Missing one or more required arguments. \n Run 'quest help [command]' for more information.");
            if (string.IsNullOrWhiteSpace(args[dontIndex]))
                throw new ArgumentException("Missing one or more required arguments. \n Run 'quest help [command]' for more information.");
            return args[dontIndex];
        }

        public static App GetAppFromCommandLineArguments(string[] args)
        {
            if (!ArgumentsHandler.HasFlag(args, "--app") || !ArgumentsHandler.HasFlag(args, "--feature"))
                throw new ArgumentException("Missing one or more required arguments. \n Run 'quest help [command]' for more information.");

            int appIndex = ArgumentsHandler.GetIndexOfFlag(args, "--app") + 1;
            int featureIndex = ArgumentsHandler.GetIndexOfFlag(args, "--feature") + 1;

            if (string.IsNullOrEmpty(args[appIndex]) || string.IsNullOrEmpty(args[featureIndex]))
                throw new ArgumentException("Missing one or more required arguments. \n Run 'quest help [command]' for more information.");
            if (string.IsNullOrWhiteSpace(args[appIndex]) || string.IsNullOrWhiteSpace(args[featureIndex]))
                throw new ArgumentException("Missing one or more required arguments. \n Run 'quest help [command]' for more information.");

            App app = new App()
            {
                Name = args[appIndex],
                Features = new List<Feature>() { new Feature() { Name = args[featureIndex] } }
            };

            Config conf = Setup.GetConfig();
            app.LocalPath = conf.Applications.FirstOrDefault(a => a.Name == app.Name).LocalPath;
            return app;
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
