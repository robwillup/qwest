namespace Quest
{
    class Program
    {   
        static void Main(string[] args)
        {
            ToDoTests toDo = new ToDoTests();
            if (args[0] == "do")
                toDo.Add(args[1]);
            else if (args[0] == "done")
                toDo.Complete(args[1]);
            else if (args[0] == "todo")
                toDo.List();
            else if (args[0] == "undo")
                toDo.Delete(args[1]);
            else if (args[0] == "version")
                System.Console.WriteLine("1.0.0");
        }
    }
}
