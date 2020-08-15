using System.IO;

namespace Quest.Commands
{
    public static class ToDo
    {
        public static string TodoText { get; set; }        
        public static void Create(string text, string path)
        {
            PrepareToDoFile(path);
            ToDoCreator.AddOne(text, $@"{path}\todos.txt");            
        }

        public static void PrepareToDoFile(string path) 
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                File.Create(@$"{path}\todos.txt");
            }
            else if (!File.Exists(@$"{path}\todos.txt"))
                File.Create(@$"{path}\todos.txt");
        }
    }
}
