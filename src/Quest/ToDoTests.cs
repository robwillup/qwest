using System.IO;

namespace Quest
{
    public class ToDoTests
    {
        public void Add(string todoText)
        {
            string todoFilePath = Path.Combine(Directory.GetCurrentDirectory(), "todo.md");
            File.WriteAllText(todoFilePath, todoText);
        }

        public void Complete(string todoText)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "todo.md");
            string content = File.ReadAllText(path);
            content = content.Replace(todoText, $"~~{todoText}~~");
            File.WriteAllText(path, content);
        }
    }
}
