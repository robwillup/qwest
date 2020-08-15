using static System.Console;
using Quest.Commands.ToDo;

namespace Quest.Console
{
    public static class ToDosUi
    {
        public static void ShowToDos(string toDosPath)
        {
            WriteLine(ToDoHandler.ListToDos(toDosPath));
        }
    }
}
