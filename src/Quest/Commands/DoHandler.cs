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
            try
            {
                Config config = Setup.GetConfig();
                string appQuestPath = Path.Combine(
                    config.Applications.FirstOrDefault(e => e.Name == todo.AppName).LocalPath, ".quest");
                FileHandler.CreateQuestDirInSourcePath(appQuestPath);
                string featurePath = Path.Combine(appQuestPath, todo.FeatureName);
                FileHandler.CreateFeatureDirInSourcePath(featurePath);
                string todoPath = Path.Combine(featurePath, "todo.md");
                string todoText = $"* {todo.Name} - ({todo.Id}) - Created at: {DateTime.Now}";
                List<string> lines = new List<string>() { todoText };                
                File.AppendAllLines(todoPath, lines);
                return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static QuestTask Handle(string[] args)
        {
            try
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

                QuestTask questTask = new QuestTask()
                {
                    Name = args[doIndex],
                    AppName = args[appIndex],
                    FeatureName = args[featureIndex]
                };

                var conf = Setup.GetConfig();
                if (conf.Applications == null || conf.Applications.Count == 0)
                    throw new Exception("Please, run 'quest help config' to learn how to create an application for Quest.");
                bool? hasFeature = conf.Applications?.FirstOrDefault(a => a.Name == questTask.AppName)
                    .Features?.Any(f => f.Name == questTask.FeatureName);
                if (hasFeature == null || hasFeature == false)
                {
                    conf.Applications.FirstOrDefault(a => a.Name == questTask.AppName)
                        .Features = new List<Feature>() { new Feature() { Name = questTask.FeatureName } };
                    YamlHandler.Update(Setup.GetConfigPath(), conf);
                }               

                return questTask;
            }
            catch (Exception)
            {                
                throw;
            }
        }
    }
}
