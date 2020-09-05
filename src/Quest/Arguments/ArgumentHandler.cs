using Quest.Commands;
using Quest.Commands.Init;
using Quest.Console;
using Quest.Files;
using Quest.Models;
using System;
using static System.Console;

namespace Quest.Arguments
{
    public static class ArgumentHandler
    {
        public static string QuestTodosPath { get; set; }
        public static int HandleArgs(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
                args[i] = args[i].ToLower();
            IQuestFile quest = new QuestFile();
            try
            {
                if (args.Length == 0)
                    WriteLine("Welcome to the Quest!");
                else
                {
                    if (args[0] == CommandNames.Help.ToString().ToLower())
                        HelpCommandUi.GetHelp("default");
                    else if (args[0] == CommandNames.Init.ToString().ToLower())
                        InitHandler.CreateQuestDirectory();
                    else if (args[0] == CommandNames.Feat.ToString().ToLower())
                        FeatHandler.HandleFeatArgs(args);
                    else if (args[0] == CommandNames.Do.ToString().ToLower())
                    {
                        string text = DoHandler.DoCommandHandler(args);
                        if (text != null)
                            DoCreator.AddOne(text, QuestTodosPath);
                    }
                    else if (args[0] == CommandNames.ToDo.ToString().ToLower())
                        ToDosUi.ShowToDos(QuestTodosPath);
                    else if (args[0] == CommandNames.Dont.ToString().ToLower())
                        DontHandler.DeleteTodo(args[1], QuestTodosPath);
                }
                return 0;
            }
            catch (ArgumentException)
            {
                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
