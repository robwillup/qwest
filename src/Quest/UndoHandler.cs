using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Quest
{
    public static class UndoHandler
    {
        public static void Undo(string todoText) 
        {
            string donePath = Path.Combine(Directory.GetCurrentDirectory(), "done.md");
            if (!File.Exists(donePath))
                return;
            string todoPath = Path.Combine(Directory.GetCurrentDirectory(), "todo.md");
            if (!File.Exists(todoPath))
                return;
            List<string> doneContent = File.ReadAllLines(donePath).ToList();
            string doneLine = doneContent.FirstOrDefault(e => e.Contains(todoText));
            doneContent.Remove(doneLine);
            File.WriteAllLines(donePath, doneContent);
            List<string> todoContent = File.ReadAllLines(todoPath).ToList();
            string todoLine = doneLine.Split("- Completed at")[0];
            todoContent.Add(todoLine);
            File.WriteAllLines(todoPath, todoContent);
        }
    }
}
