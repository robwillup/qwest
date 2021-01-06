using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Quest.Commands
{
    public static class UndoHandler
    {
        public static int Undo(string[] args, string doneFilePath = "", string todoFilePath = "") 
        {
            if (args.Length < 2)
            {
                Console.WriteLine("The 'undo' command requires at least one argument.");
                return 1;
            }
            string todoText = args[1];
            string donePath = string.IsNullOrEmpty(doneFilePath) ? Path.Combine(Directory.GetCurrentDirectory(), "done.md") : doneFilePath;
            if (!File.Exists(donePath))
                return 1;
            string todoPath = string.IsNullOrEmpty(todoFilePath) ? Path.Combine(Directory.GetCurrentDirectory(), "todo.md") : todoFilePath;
            if (!File.Exists(todoPath))
                return 1;
            List<string> doneContent = File.ReadAllLines(donePath).ToList();
            if (doneContent == null || doneContent.Count == 0)
                return 1;
            string doneLine = doneContent.FirstOrDefault(e => e.Contains(todoText));
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
