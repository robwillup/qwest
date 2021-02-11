using Quest.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Quest.Commands
{
    public static class UndoHandler
    {
        public static int Handle(string[] args)
        {
            string undoText = ArgumentsHandler.GetTaskTextFromCommandLineArguments(args, "undo");
            App app = ArgumentsHandler.GetAppFromCommandLineArguments(args);
            return Undo(undoText, app);
        }
        public static int Undo(string undoText, App app) 
        {
            string donePath = Path.Combine(app.LocalPath, ".quest", app.Features.First().Name, "done.md");
            string todoPath = Path.Combine(app.LocalPath, ".quest", app.Features.First().Name, "todo.md");
            List<string> doneContent = File.ReadAllLines(donePath).ToList();
            if (doneContent == null || doneContent.Count == 0)
                return 1;            
            string doneLine = doneContent.FirstOrDefault(e => e.Contains(undoText));
            doneContent.Remove(doneLine);
            File.WriteAllLines(donePath, doneContent);
            List<string> todoContent = File.ReadAllLines(todoPath).ToList();
            if (todoContent == null)
                return 1;
            string todoLine = doneLine.Split("- Completed at")[0];
            todoContent.Add(todoLine);
            File.WriteAllLines(todoPath, todoContent);
            return 0;
        }
    }
}
