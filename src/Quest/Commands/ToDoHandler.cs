using Quest.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Quest.Commands
{
    public static class ToDoHandler
    {
        public static int List(App app)
        {
            string path = Path.Combine(app.LocalPath, ".quest");            
            if (app.Features != null && app.Features.Count() > 0)
                path = Path.Combine(path, app.Features.FirstOrDefault(e => true).Name);
            
            string[] files = Directory.GetFiles(path, "todo.md", SearchOption.AllDirectories);            
            foreach (string file in files)
            {
                List<string> content = File.ReadAllLines(file).ToList();
                if (!content.Any(l => l.Contains("*")))
                    continue;
                Console.WriteLine($"Feature: {new DirectoryInfo(file).Parent.Name}");
                foreach (string line in content)
                    Console.WriteLine(line);
            }

            return 0;
        }

        public static App Handle(string[] args)
        {
            try
            {
                if (args.Length < 3)
                    throw new ArgumentException("Missing one or more required arguments. \n Run 'quest help [command]' for more information.");
                if (!ArgumentsHandler.HasFlag(args, "--app"))
                    throw new ArgumentException("Missing one or more required arguments. \n Run 'quest help [command]' for more information.");
                if (ArgumentsHandler.HasFlag(args, "--feature") && !ArgumentsHandler.HasFlag(args, "--app"))
                    throw new ArgumentException("Missing one or more required arguments. \n Run 'quest help [command]' for more information.");

                int appIndex = ArgumentsHandler.GetIndexOfFlag(args, "--app") + 1;

                int featureIndex = 0;
                if (ArgumentsHandler.HasFlag(args, "--feature"))
                   featureIndex = ArgumentsHandler.GetIndexOfFlag(args, "--feature") + 1;

                if (string.IsNullOrEmpty(args[appIndex]) || string.IsNullOrWhiteSpace(args[appIndex]))
                    throw new ArgumentException("Missing one or more required arguments. \n Run 'quest help [command]' for more information.");
                else if (ArgumentsHandler.HasFlag(args, "--feature") && string.IsNullOrWhiteSpace(args[featureIndex]) || string.IsNullOrEmpty(args[featureIndex]))
                    throw new ArgumentException("Missing one or more required arguments. \n Run 'quest help [command]' for more information.");

                var conf = Setup.GetConfig();
                if (conf.Applications == null || conf.Applications.Count == 0)
                    throw new Exception("Could not find any applications to list tasks. Please, run 'quest config list' to learn how to create an application for Quest.");

                App app = new App()
                {
                    Name = args[appIndex],
                    LocalPath = conf.Applications.FirstOrDefault(a => a.Name == args[appIndex]).LocalPath
                };

                if (featureIndex != 0)
                {
                    bool? hasFeature = conf.Applications?.FirstOrDefault(a => a.Name == args[appIndex])
                                           .Features?.Any(f => f.Name == args[featureIndex]);

                    if (hasFeature == null || hasFeature == false)
                    {
                        Console.WriteLine(@$"Feature ""{args[featureIndex]}"" was not found in application ""{args[appIndex]}""");
                        Console.WriteLine("Getting all features...");                        
                        return app;
                    }
                    app.Features = new List<Feature>() { new Feature() { Name = args[featureIndex] } };
                    return app;
                }
                return app;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}