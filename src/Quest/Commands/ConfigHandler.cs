using Quest.Models;
using static System.Console;

namespace Quest.Commands
{
    public static class ConfigHandler
    {
        public static int Handle(string[] args)
        {
            if (args.Length == 2)
            {
                if (args[1] == "--list")
                    List();
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
            foreach (App app in config.Applications)
            {
                WriteLine("Applications:");
                WriteLine($"\tApp name: {app.Name}");
                WriteLine($"\tApp path: {app.LocalPath}");
                WriteLine();
                foreach (Feature feature in app.Features)
                {
                    WriteLine("\tFeatures:");
                    WriteLine($"\t\tFeature name: {feature.Name}");
                    WriteLine();
                }
            }
            return 0;
        }
    }
}
