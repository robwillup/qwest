using Quest.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Quest
{
    public static class YamlHandler
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
            });
            File.WriteAllText(path, configStr);
        }

        public static void Update(string path, Config content)
        {
            var serializer = new YamlDotNet.Serialization.Serializer();
            string configStr = serializer.Serialize(content);
            File.WriteAllText(path, configStr);
        }
    }
}
