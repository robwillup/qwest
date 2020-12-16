using System;
using System.IO;

namespace Quest.Commands
{
    public static class ToDoHandler
    {
        public static void List()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "todo.md");
            if(File.Exists(path))
                Console.Write(File.ReadAllText(path));
            else
                Console.WriteLine("No active tasks in the default path (current directory).");
        }
    }
}