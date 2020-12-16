using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Quest.Commands
{
    public static class UndoHandler
    {
        public static int Undo(string[] args) 
        {
            if (args.Length < 2)
            {
                Console.WriteLine("The 'undo' command requires at least one argument.");
                return 1;
            }
            string todoText = args[1];
            string donePath = Path.Combine(Directory.GetCurrentDirectory(), "done.md");
            if (!File.Exists(donePath))
                return 1;
            string todoPath = Path.Combine(Directory.GetCurrentDirectory(), "todo.md");
            if (!File.Exists(todoPath))
                return 1;
            List<string> doneContent = File.ReadAllLines(donePath).ToList();
            string doneLine = doneContent.FirstOrDefault(e => e.Contains(todoText));
            doneContent.Remove(doneLine);
            File.WriteAllLines(donePath, doneContent);
            List<string> todoContent = File.ReadAllLines(todoPath).ToList();
            string todoLine = doneLine.Split("- Completed at")[0];
            todoContent.Add(todoLine);
            File.WriteAllLines(todoPath, todoContent);
            return 0;
        }
    }
}
