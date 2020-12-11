using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Quest
{
    public static class DontHandler
    {
        public static bool Remove(string todo)
        {
            string todoPath = Path.Combine(Directory.GetCurrentDirectory(), "todo.md");
            if (!File.Exists(todoPath))
                return false;
            List<string> todoContent = File.ReadAllLines(todoPath).ToList();
            todoContent.Remove(todoContent.FirstOrDefault(t => t.Contains(todo)));
            File.WriteAllLines(todoPath, todoContent);
            return true;
        }
    }
}
