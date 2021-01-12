using Quest.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Quest
{
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
