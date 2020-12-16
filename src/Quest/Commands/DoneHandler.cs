using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Quest.Commands
{
    public static class DoneHandler
    {
        public static int HandleDone(string[] args)
        {
            if (args.Length == 2)
                Complete(args[1]);
            else
                ListDone();
            return 0;
        }

        public static void Complete(string todoText)
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

        public static void ListDone()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "done.md");
            if (File.Exists(path))
                Console.WriteLine(File.ReadAllText(path));
            else
                Console.WriteLine("No completed tasks in the default path (current directory).");
        }
    }
}
