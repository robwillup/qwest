using Quest.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Quest.Commands
{
    public static class UndoHandler
    {
        public static int Handle(string[] args)
        {
            string undoText = GetUndoTextFromCommandLineArguments(args);
            App app = GetAppFromCommandLineArguments(args);
            return Undo(undoText, app);
        }
        public static int Undo(string undoText, App app) 
        {
            string donePath = Path.Combine(app.LocalPath, ".quest", app.Features.First().Name, "done.md");
            string todoPath = Path.Combine(app.LocalPath, ".quest", app.Features.First().Name, "todo.md");
            List<string> doneContent = File.ReadAllLines(donePath).ToList();
            if (doneContent == null || doneContent.Count == 0)
                return 1;            
            string doneLine = doneContent.FirstOrDefault(e => e.Contains(undoText));
            doneContent.Remove(doneLine);
            File.WriteAllLines(donePath, doneContent);
            List<string> todoContent = File.ReadAllLines(todoPath).ToList();
            if (todoContent == null)
                return 1;
            string todoLine = doneLine.Split("- Completed at")[0];
            todoContent.Add(todoLine);
            File.WriteAllLines(todoPath, todoContent);
            return 0;
        }

        public static string GetUndoTextFromCommandLineArguments(string[] args)
        {
            int undoIndex = ArgumentsHandler.GetIndexOfFlag(args, "undo") + 1;
            if (string.IsNullOrEmpty(args[undoIndex]))
                throw new ArgumentException("Missing one or more required arguments. \n Run 'quest help [command]' for more information.");
            if (string.IsNullOrWhiteSpace(args[undoIndex]))
                throw new ArgumentException("Missing one or more required arguments. \n Run 'quest help [command]' for more information.");
            return args[undoIndex];
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
    }
}
