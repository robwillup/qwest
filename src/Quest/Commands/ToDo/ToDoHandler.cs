using System.IO;
using System.Text;

namespace Quest.Commands.ToDo
{
    public static class ToDoHandler
    {        
        public static string ListToDos(string toDosPath)
        {
            string[] lines = File.ReadAllLines(@$"{toDosPath}\todos.txt");
            StringBuilder sb = new StringBuilder();
            foreach (string line in lines)
                sb.AppendLine(line);
            return sb.ToString();
        }
    }
}
