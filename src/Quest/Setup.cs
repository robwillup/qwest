using System;
using System.IO;

namespace Quest
{
    public static class Setup
    {
        public static string GetConfigPath()
        {
            return Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.UserProfile), ".quest", "config.yml");
        }
        public static void HandleConfiguration(string[] args)
        {
            if (args.Length == 1 && args[0] == "version")
                return;
            if (!Directory.Exists(Path.GetDirectoryName(GetConfigPath())))
            {
                string answer = "";
                do
                {
                    Console.WriteLine("Quest's global config not found.");
                    Console.WriteLine("Would you like to create it now?");
                    Console.WriteLine("[Y] Yes\n[N] No");
                    answer = Console.ReadLine();
                    answer = answer.ToLower();
                } while (answer != "yes" && answer != "y" && answer != "n" && answer != "no");
                if (answer == "no" || answer == "n")
                {
                    Console.WriteLine("Bye");
                    return;
                }
                else
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(GetConfigPath()));
                    using (File.Create(GetConfigPath())) { } ;
                }

                YamlCreator.Create(GetConfigPath());
            }
        }
    }
}
