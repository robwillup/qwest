using Quest.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Quest
{
    public static class YamlCreator
    {
        public static void Create(string path, string githubUsername)
        {
            var serializer = new YamlDotNet.Serialization.Serializer();
            string configStr = serializer.Serialize(new Config() 
            {
                App = "Quest - Work Management for Developers",
                Date = DateTime.Now,
                Dev = new Dev() { Username = githubUsername},
                Applications = new List<App>() 
                { 
                    new App() 
                    {
                        Name = "quest_elixir",
                        LocalPath = @"C:\Users\rwill\source\repos\QuestSources\quest_elixir",
                        Remote = "https://github.com/robwillup/quest_elixir.git",
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
