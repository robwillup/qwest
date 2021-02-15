using Quest.Models;
using Quest.ObjectParsers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Console;

namespace Quest.Commands
{
    public static class ToDo
    {
        public static string Handle(string[] args)
        {
            try
            {
                string path = "";
                if (args.Length > 1) 
                {                    
                    App app = AppParser.GetAppFromCommandLineArguments(args);
                    path = Path.Combine(app.LocalPath, ".quest");
                    if (app.Features != null && app.Features.Count() > 0)
                        path = Path.Combine(path, app.Features.FirstOrDefault(e => true).Name);
                }
                return path;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int List(string path)
        {
            List<string> files = new List<string>();
            if (string.IsNullOrEmpty(path))
                files = GetAllToDos();
            else
            {   
                files = Directory.GetFiles(path, "todo.md", SearchOption.AllDirectories).ToList();
            }            
            foreach (string file in files)
            {
                List<string> content = File.ReadAllLines(file).ToList();
                if (!content.Any(l => l.Contains("*")))
                    continue;
                WriteLine($"Feature: {new DirectoryInfo(file).Parent.Name}");
                foreach (string line in content)
                    WriteLine(line);
                WriteLine();
            }
            return 0;
        }

        private static List<string> GetAllToDos()
        {
            Models.Config config = Setup.GetConfig();
            if (config.Applications == null || config.Applications.Count == 0)
                return new List<string>();
            List<string> files = new List<string>();
            List<App> allApps = config.Applications;
            foreach (App app in allApps)
            {
                var todoFiles = Directory.GetFiles(Path.Combine(app.LocalPath, ".quest"), "todo.md", SearchOption.AllDirectories);
                foreach (string file in todoFiles)
                    files.Add(file);
            }
            return files;
        }
    }
}