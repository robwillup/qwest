using System;
using System.Collections.Generic;
using System.IO;

namespace Quest
{
    public class Config
    {
        public string App { get; set; }
        public DateTime Date { get; set; }
        public Dev Dev { get; set; }
        public List<App> Applications { get; set; }
    }

    public class Dev
    {
        public string Username { get; set; }
    }

    public class App
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public List<Feature> Features { get; set; }
    }

    public class Feature
    {
        public string Name { get; set; }
    }
    public static class YamlCreator
    {
        public static void Create(string path)
        {
            var serializer = new YamlDotNet.Serialization.Serializer();
            string configStr = serializer.Serialize(new Config() 
            {
                App = "Quest - Work Management for Developers",
                Date = DateTime.Now,
                Dev = new Dev() { Username = Environment.GetEnvironmentVariable("USERPROFILE")},
                Applications = new List<App>() 
                { 
                    new App() 
                    {
                        Name = "quest_elixir",
                        Path = @"C:\Users\rwill\source\repos\QuestSources\quest_elixir",
                        Features = new List<Feature>()
                        {
                            new Feature() { Name = "ReadYaml" }
                        }
                    } }
            });
            File.WriteAllText(path, configStr);
        }        
    }
}
