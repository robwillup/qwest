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
            if (string.IsNullOrEmpty(todoText) || string.IsNullOrWhiteSpace(todoText))
            {
                Console.WriteLine("The 'do' command must recieve at least one character.");
                return;
            }
            var guid = Guid.NewGuid();
            string todoFilePath = Path.Combine(Directory.GetCurrentDirectory(), "todo.md");
            if (!File.Exists(todoFilePath))
                using (File.Create(todoFilePath)) { } ;
            todoText = $"* {todoText} - ({guid}) - Created at: {DateTime.Now}";
            File.AppendAllLines(todoFilePath, new string[] { todoText });
        }

        public void Complete(string todoText)
        {
            string donePath = Path.Combine(Directory.GetCurrentDirectory(), "done.md");
            if (!File.Exists(donePath))
                using (File.Create(donePath)) { };
            string todoPath = Path.Combine(Directory.GetCurrentDirectory(), "todo.md");
            List<string> lines = File.ReadAllLines(todoPath).ToList();
            string line = lines.Find(t => t.Contains(todoText));            
            lines.Remove(line);
            File.WriteAllLines(todoPath, lines);            
            File.AppendAllText(donePath, $"{line} - Completed at: {DateTime.Now}\n");
        }

        public void List()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "todo.md");
            if(File.Exists(path))
                Console.Write(File.ReadAllText(path));
            else
                Console.WriteLine("No 'todo.md' file found in this directory.");
        }

        public void ListDone()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "done.md");
            if (File.Exists(path))
                Console.WriteLine(File.ReadAllText(path));
            else
                Console.WriteLine("No completed task in the default path (current directory).");
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