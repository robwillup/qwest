using Quest.Models;
using Quest.ObjectParsers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Quest.Commands
{
    public static class ListDone
    {
        public static bool Handle(string[] args)
        {
            if (args.Length == 1)
                return List(GetDoneFiles(null));
            App app = AppParser.GetAppWithFeatureFromCommandLineArguments(args);
            return List(GetDoneFiles(app));
        }

        private static bool List(List<string> files)
        {
            foreach (string file in files)
            {
                List<string> content = File.ReadAllLines(file).ToList();
                if (!content.Any(l => l.Contains("*")))
                    continue;
                Console.WriteLine($"Feature: {new DirectoryInfo(file).Parent.Name}");
                foreach (string line in content)
                    Console.WriteLine(line);
            }
            return true;
        }

        private static List<string> GetDoneFiles(App app)
        {
            List<string> files = new List<string>();

            if (app == null)
            {
                Models.Config config = Setup.GetConfig();
                if (config.Applications != null || config.Applications.Count > 0)
                {
                    List<App> allApps = config.Applications;
                    foreach (App a in allApps)
                    {
                        var todoFiles = Directory.GetFiles(Path.Combine(a.LocalPath, ".quest"), "done.md", SearchOption.AllDirectories);
                        foreach (string file in todoFiles)
                            files.Add(file);
                    }
                }
                return files;
            }
            string path = Path.Combine(app.LocalPath, ".quest");
            if (app.Features != null && app.Features.Count() > 0)
                path = Path.Combine(path, app.Features.FirstOrDefault(e => true).Name);
            files = Directory.GetFiles(path, "done.md", SearchOption.AllDirectories).ToList();
            return files;
        }
    }
}
