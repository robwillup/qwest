using Quest.Commands;
using System;

namespace Quest
{
    public static class CommandHandler
    {
        public static bool Run(string[] args, string command)
        {
            try
            {
                if (command == "do")
                    return DoHandler.Handle(args) == 0;
                else if (command == "done")
                    DoneHandler.Handle(args);
                else if (command == "todo")
                    return ToDoHandler.List(ToDoHandler.Handle(args)) == 0;
                else if (command == "undo")
                    return UndoHandler.Handle(args);
                else if (command == "dont")
                    return DontHandler.Handle(args);
                else if (command == "version")
                    Console.WriteLine("1.0.0");
                else if (command == "help")
                    HelpHandler.HandleHelp(args);
                else if (command == "config")
                    ConfigHandler.Handle(args);
                else
                    Console.WriteLine($"Command \"{args[0]}\" is undefined.");
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
