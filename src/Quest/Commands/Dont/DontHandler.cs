using System.IO;
using System.Linq;
using Quest.Commands.ToDo;
using System.Collections.Generic;

namespace Quest.Commands
{
    public static class DontHandler
    {
        public static void DeleteTodo(string hash, string path)
        {            
            List<string> toDos = ToDoHandler.ListToDos(path).ToList();
            foreach (string todo in toDos)
            {
                if (todo.Contains(hash))
                {
                    toDos.Remove(todo);
                    break;
                }
            }
            path = $"{path}\\Quest.md";
            File.WriteAllLines(path, toDos);
        }
    }
}
