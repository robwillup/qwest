using static System.Console;
using Quest.Commands.ToDo;

namespace Quest.Console
{
    public static class ToDosUi
    {
        public static void ShowToDos(string toDosPath)
        {
            foreach (string todo in ToDoHandler.ListToDos(toDosPath))
                WriteLine(todo);
        }
    }
}
