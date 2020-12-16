using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Quest.Commands
{
    public static class ToDoHandler
    {
        public static int List()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "todo.md");
            if (File.Exists(path))
            {
                List<string> content = File.ReadAllLines(path).ToList();
                if (!content.Any(l => l.Contains("*")))
                {
                    Console.WriteLine("No active tasks in the default path (current directory).");
                    return 1;
                }
                foreach (string line in content)
                    Console.WriteLine(line);
            }
            else
            {
                Console.WriteLine("No active tasks in the default path (current directory).");
                return 1;
            }
            return 0;
        }
    }
}