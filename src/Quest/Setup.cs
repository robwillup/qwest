using Quest.Models;
using System;
using System.IO;
using YamlDotNet.Serialization;

namespace Quest
{
    public static class Setup
    {
        public static string GetConfigPath()
        {
            return Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.UserProfile), ".quest", "config.yml");
        }

        public static int HandleConfiguration(string[] args)
        {
            if (args.Length == 1 && args[0] == "version")
                return 0;
            if (Directory.Exists(Path.GetDirectoryName(GetConfigPath())))
                return 0;
            
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
                return 0;

            string githubUsername;
            Console.WriteLine("Please, what is your GitHub username?");
            githubUsername = Console.ReadLine();
            Directory.CreateDirectory(Path.GetDirectoryName(GetConfigPath()));
            using (File.Create(GetConfigPath())) { } ;
            YamlCreator.Create(GetConfigPath(), githubUsername);
            return 0;
        }

        public static Config GetConfig()
        {
            string content = File.ReadAllText(GetConfigPath());
            var deserializer = new Deserializer();
            return deserializer.Deserialize<Config>(content);
        }
    }
}
