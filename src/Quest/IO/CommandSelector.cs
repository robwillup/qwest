using Quest.Commands;
using System;

namespace Quest
{
    public static class CommandSelector
    {
        public static int Run(string[] args, string command)
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
                ConfigHandler.Handle(args);
            else
                Console.WriteLine($"Command \"{args[0]}\" is undefined.");
            return 0;
        }
    }
}
