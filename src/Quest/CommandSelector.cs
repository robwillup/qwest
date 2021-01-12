using Quest.Commands;
using Quest.Models;
using System;

namespace Quest
{
    public static class CommandSelector
    {
        public static int Select(string[] args, string command)
        {
            if (command == "do")
                return DoHandler.Add(DoHandler.Handle(args));
            else if (command == "done")
                DoneHandler.HandleDone(args);
            else if (command == "todo")
                return ToDoHandler.List();
            else if (command == "undo")
                return UndoHandler.Undo(args);
            else if (command == "dont")
                return DontHandler.Remove(args);
            else if (command == "version")
                Console.WriteLine("1.0.0");
            else if (command == "help")
                HelpHandler.HandleHelp(args);
            else if (command == "config")
            {
                if (args.Length == 2 && args[1] == "--list")
                {
                    var config = Setup.GetConfig();                    
                    Console.WriteLine($"Developer: {config.Dev.Username}");
                    foreach (App app in config.Applications)
                    {
                        Console.WriteLine("Applications:");
                        Console.WriteLine($"\tApp name: {app.Name}");
                        Console.WriteLine($"\tApp path: {app.Path}");
                        Console.WriteLine();
                        foreach (Feature feature in app.Features)
                        {
                            Console.WriteLine("\tFeatures:");
                            Console.WriteLine($"\t\tFeature name: {feature.Name}");
                            Console.WriteLine();
                        }
                    }
                }
            }
            else
                Console.WriteLine($"Command \"{args[0]}\" is undefined.");
            return 0;
        }
    }
}
