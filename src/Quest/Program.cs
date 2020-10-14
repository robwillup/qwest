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
            ArgumentsHandler.Handle(args);            
        }
    }
}
