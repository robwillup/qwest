using System.Linq;
using static System.Console;

namespace Quest
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length == 0)
                WriteLine("Welcome to the Quest!");
            else if (args.Contains("new"))
            {
                if (!args.Contains("--todo"))
                {
                    WriteLine(@"When the 'new' command is used, the '--todo' flag must be provided, as well as its text.");
                    return 1;
                }
                else
                {
                    int todoIndex = args.ToList().IndexOf("--todo");                    
                    if (todoIndex + 1 < args.Length && !string.IsNullOrEmpty(args[todoIndex + 1]))
                    {
                        string todoText = args[todoIndex + 1];
                        WriteLine(todoText);
                    }
                    else
                        WriteLine("A text for the '--todo' flag must be provided.");
                    
                }
            }
            return 0;
        }
    }
}
