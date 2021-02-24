using static System.Console;
using Quest.Models;

namespace Quest.IO
{
    public static class ConfigDisplayer
    {
        public static void DisplayConfig(Configuration config)
        {
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
                        WriteLine($"\t\tName: {feature.Name}");
                    }
                }
                WriteLine();
            }
        }
    }
}
