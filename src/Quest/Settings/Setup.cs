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
            if (args.Length < 1)
                return false;
            if (args[0] == "version" || args[0] == "help")                
                    return false;
            if (Directory.Exists(Path.GetDirectoryName(GetConfigPath()))) 
                    return false;
            return true;
        }

        private static int CreateConfig()
        {
            string path = GetConfigPath();
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            using (File.Create(path)) { };
            YamlHandler.Create(path, ConfigCreationDialog.GetUsername());
            return 0;
        }

        public static string GetConfigPath()
        {
            string path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".quest", "config.yml");
            return path;
        }

        public static Config GetConfig()
        {
            try
            {
                string content = File.ReadAllText(GetConfigPath());
                Deserializer deserializer = new Deserializer();
                return deserializer.Deserialize<Config>(content);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
