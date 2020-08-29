using Quest.Commands;
using Quest.Commands.Feat;
using Quest.Console;
using Quest.Files;
using Quest.Models;
using System;
using System.IO;
using static System.Console;

namespace Quest.Arguments
{
    public static class ArgumentHandler
    {
        public static string QuestTodosPath { get; set; }
        public static int HandleArgs(string[] args)
        {
            IQuestFile quest = new QuestFile();
            if (args.Length == 0)
                WriteLine("Welcome to the Quest!");
            else
            {
                switch (args[0])
                {
                    case CommandNames.HELP:
                        HelpCommandUi.GetHelp("default");
                        break;
                    case CommandNames.FEAT:
                        Feature feature = FeatHandler.GetFeature(args);
                        if (feature == null)
                            return 1;
                        System.Console.WriteLine(feature.Name);
                        System.Console.WriteLine(feature.Path);
                        System.Console.WriteLine(feature.Description);
                        break;
                    case CommandNames.DO:
                        string text = DoHandler.DoCommandHandler(args);
                        if (text != null)
                            DoCreator.AddOne(text, QuestTodosPath);
                        break;
                    case CommandNames.TODO:
                        ToDosUi.ShowToDos(QuestTodosPath);
                        break;
                    case CommandNames.DONT:
                        DontHandler.DeleteTodo(args[1], QuestTodosPath);
                        break;
                }
            }
            return 0;
        }
    }
}
