using System;
using System.IO;
using YamlDotNet.RepresentationModel;

namespace Quest
{
    public static class YamlCreator
    {
        public static void Create(string path)
        {
            var stream = new YamlStream(
                new YamlDocument(
                    new YamlMappingNode(
                        new YamlScalarNode("app"), new YamlScalarNode("Quest - The developer To Do app"),
                        new YamlScalarNode("date"), new YamlScalarNode(DateTime.Today.ToShortDateString()),
                        new YamlScalarNode("dev"), new YamlMappingNode(
                            new YamlScalarNode("username"), new YamlScalarNode(Environment.UserName)
                        ),
                        new YamlScalarNode("applications"), new YamlSequenceNode(
                            new YamlMappingNode(
                                new YamlScalarNode("name"), new YamlScalarNode("quest_elixir"),
                                new YamlScalarNode("path"), new YamlScalarNode(@"C:\Users\rwill\source\repos\QuestSources\quest_elixir"),
                                new YamlScalarNode("features"), new YamlSequenceNode(
                                    new YamlMappingNode(
                                        new YamlScalarNode("name"), new YamlScalarNode("ReadArguments")
                                    )
                                )
                            )
                        )
                    )
                )
            );
            using (File.Create(path)) { };
            using StreamWriter sw = new StreamWriter(path);
            stream.Save(sw, assignAnchors: false);
        }
    }
}
