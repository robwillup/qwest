using System.IO;

namespace Quest.Commands
{
    public static class NewToDo
    {
        public static string TodoText { get; set; }        
        public static void Create(string text, string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                File.Create(@$"{path}\todos.txt");
            }
            else if (!File.Exists(@$"{path}\todos.txt"))
                File.Create(@$"{path}\todos.txt");

            ToDoCreator.AddOne(text, $@"{path}\todos.txt");            
        }
    }
}
