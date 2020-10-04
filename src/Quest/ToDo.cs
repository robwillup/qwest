using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Quest
{
    public class ToDo
    {
        public void Add(string todoText)
        {
            var guid = Guid.NewGuid();
            string todoFilePath = Path.Combine(Directory.GetCurrentDirectory(), "todo.md");
            todoText = $"* {todoText} - ({guid})";
            File.AppendAllLines(todoFilePath, new string[] { todoText });
        }

        public void Complete(string todoText)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "todo.md");
            List<string> lines = File.ReadAllLines(path).ToList();
            string line = lines.Find(t => t.Contains(todoText));            
            lines.Remove(line);
            lines.Add($"{line.Replace("* ", "* ~~")}~~");
            File.WriteAllLines(path, lines);
        }

        public void List()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "todo.md");
            Console.WriteLine(File.ReadAllText(path));
        }

        public void Delete(string todo)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "todo.md");
            List<string> lines = File.ReadAllLines(path).ToList();
            string line = lines.Find(t => t.Contains(todo));
            lines.Remove(line);
            File.WriteAllLines(path, lines);
        }
    }
}