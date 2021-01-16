using Quest.Models;
using System.Linq;
using static System.Console;

namespace Quest.Commands
{
    public static class ConfigHandler
    {
        public static int Handle(string[] args)
        {
            if (args.Length > 1)
            {
                if (args[1] == "list")
                    List();
                else if (args[1] == "add")
                    Add(args);
                else if (args[1] == "rm")
                    Delete(args);
            }
            else
            {
                string[] helpArgs = new string[2] { "help", "config" };
                HelpHandler.HandleHelp(helpArgs);
                return 1;
            }
            return 0;
        }

        public static int List()
        {
            var config = Setup.GetConfig();
            WriteLine($"Developer: {config.Dev.Username}");
            WriteLine("Applications:");
            foreach (App app in config.Applications)
            {                
                WriteLine($"\tApp name: {app.Name}");
                WriteLine($"\tLocal path: {app.LocalPath}");
                WriteLine($"\tRemote: {app.Remote}");
                if (app.Features != null)
                {
                    WriteLine("\tFeatures:");
                    foreach (Feature feature in app.Features)
                    {                        
                        WriteLine($"\t\tFeature name: {feature.Name}");                        
                    }
                }
                WriteLine();
            }
            return 0;
        }

        public static int Add(string[] args)
        {
            if (!ArgumentsHandler.HasFlag(args, "--name"))
                return 1;
            if (!ArgumentsHandler.HasFlag(args, "--local-path"))
                return 1;
            if (!ArgumentsHandler.HasFlag(args, "--remote"))
                return 1;
            int ni = ArgumentsHandler.GetIndexOfFlag(args, "--name") + 1;
            int lpi = ArgumentsHandler.GetIndexOfFlag(args, "--local-path") + 1;
            int ri = ArgumentsHandler.GetIndexOfFlag(args, "--remote") + 1;
            App app = new App() { Name = args[ni], LocalPath = args[lpi], Remote = args[ri] };
            var conf = Setup.GetConfig();
            conf.Applications.Add(app);
            YamlHandler.Update(Setup.GetConfigPath(), conf);
            return 0;
        }

        public static int Delete(string[] args)
        {
            if (!ArgumentsHandler.HasFlag(args, "--name"))
                return 1;
            string name = args[ArgumentsHandler.GetIndexOfFlag(args, "--name") + 1];
            var conf = Setup.GetConfig();
            conf.Applications.Remove(conf.Applications.FirstOrDefault(e => e.Name == name));
            YamlHandler.Update(Setup.GetConfigPath(), conf);
            return 0;
        }
    }
}
