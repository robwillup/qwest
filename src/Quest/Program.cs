using System;
using System.IO;

namespace Quest
{
    class Program
    {   
        static void Main(string[] args)
        {
            // Check config file
            string userProfilePath = Path.Combine(
                                        Environment.GetFolderPath(
                                            Environment.SpecialFolder.UserProfile), ".quest");
            if (!Directory.Exists(userProfilePath))
            {
                string answer = "";
                do {
                    Console.WriteLine("Quest's global config not found.");
                    Console.WriteLine("Would you like to create it now?");
                    Console.WriteLine("[Y] Yes\n[N] No");
                    answer = Console.ReadLine();
                    answer = answer.ToLower();
                } while (answer != "yes" && answer != "y" && answer != "n" && answer != "no");
                if (answer == "no" || answer == "n")
                {
                    Console.WriteLine("Bye"); 
                    return;
                }
                else
                {
                    Directory.CreateDirectory(userProfilePath);
                    File.Create(Path.Combine(userProfilePath, "config.yml"));
                }
            }
            // Work with arguments
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
