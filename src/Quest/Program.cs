using System;
using System.IO;

namespace Quest
{
    class Program
    {   
        static void Main(string[] args)
        {
            // Check config file
            Setup.HandleConfiguration();
            // Work with arguments
            ToDo toDo = new ToDo();
            if (args[0] == "do")
                toDo.Add(args[1]);
            else if (args[0] == "done")
                toDo.Complete(args[1]);
            else if (args[0] == "todo")
                toDo.List();
            else if (args[0] == "undo")
                toDo.Delete(args[1]);
            else if (args[0] == "version")
                Console.WriteLine("1.0.0");
        }
    }
}
