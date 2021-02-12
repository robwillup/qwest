using System;
using System.IO;
using System.Collections.Generic;
using Quest.Models;
using System.Linq;
using Quest.IO;
using Quest.ObjectParsers;

namespace Quest.Commands
{
    public static class DoHandler
    {
        public static int Handle(string[] args)
        {
            try
            {
                int doTextIndex = CommandLineArguments.GetIndexOfFlag(args, "do") + 1;
                if (CommandLineArguments.IsArgumentValid(args, doTextIndex))
                    throw new ArgumentException("Missing one or more required arguments. \n Run 'quest help [command]' for more information.");
                string doText = args[doTextIndex];
                App app = AppParser.GetAppFromCommandLineArguments(args);
                return Add(doText, app);
            }
            catch (Exception)
            {                
                throw;
            }
        }

        public static int Add(string doText, App app)
        {
            try
            {
                Config config = Setup.GetConfig();
                string todoDirPath = Path.Combine(app.LocalPath, ".quest", app.Features.First().Name);                                                                
                string todoText = $"* {doText} - ({Guid.NewGuid()}) - Created at: {DateTime.Now}";
                List<string> lines = new List<string>() { todoText };
                DirectoryInfo dir = Directory.CreateDirectory(todoDirPath);                                
                File.AppendAllLines(Path.Combine(todoDirPath, "todo.md"), lines);
                return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
