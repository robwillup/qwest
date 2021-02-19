using Quest.IO;
using Quest.Models;
using System;
using System.IO;
using YamlDotNet.Serialization;

namespace Quest
{
    public static class Setup
    {
        public static bool HandleConfiguration(string[] args)
        {            
            if (!ShouldCreateConfigFile(args))
                return true;
            if(!ConfigCreationDialog.GetUserConfirmation())                
                return false;            
            return CreateConfig();
        }

        public static bool ShouldCreateConfigFile(string[] args)
        {            
            if (args.Length < 1)
                return false;
            if (args[0] == "version" || args[0] == "help")                
                return false;
            if (File.Exists(GetConfigPath()))
                return false;
            return true;
        }

        private static bool CreateConfig()
        {
            string path = GetConfigPath();
            Console.WriteLine(path);
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            using (File.Create(path)) { };
            YamlHandler.Create(path, ConfigCreationDialog.GetUsername());
            return true;
        }

        public static string GetConfigPath()
        {
            string path = Environment.GetEnvironmentVariable("QUEST_PATH");            
            if (string.IsNullOrEmpty(path))
                path = Path.Combine(
                       Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".quest", "config.yml");
            else
                path = Path.Combine(path, "config.yml");
            return path;
        }

        public static Config GetConfig()
        {
            try
            {
                FileInfo fi = new FileInfo(GetConfigPath());
                using var sr = fi.OpenText();
                string content = sr.ReadToEnd();                
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
