using Quest.IO;
using Quest.Models;
using System;
using System.IO;
using YamlDotNet.Serialization;

namespace Quest
{
    public static class Setup
    {
        public static int HandleConfiguration(string[] args)
        {
            if (!ShouldCreateConfigFile(args))
                return 0;
            if(!ConfigCreationDialog.GetUserConfirmation())                
                return 1;            
            return CreateConfig();
        }

        public static bool ShouldCreateConfigFile(string[] args)
        {            
            if (args.Length > 0)
            {
                if (args[0] == "version" || args[0] == "help")
                    return false;
            }
            if (Directory.Exists(Path.GetDirectoryName(GetConfigPath())))
                return false;
            return true;
        }

        private static int CreateConfig()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(GetConfigPath()));
            using (File.Create(GetConfigPath())) { };
            YamlHandler.Create(GetConfigPath(), ConfigCreationDialog.GetUsername());
            return 0;
        }

        public static string GetConfigPath()
        {
            return Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.UserProfile), ".quest", "config.yml");
        }

        public static Config GetConfig()
        {
            string content = File.ReadAllText(GetConfigPath());
            Deserializer deserializer = new Deserializer();
            return deserializer.Deserialize<Config>(content);
        }
    }
}
