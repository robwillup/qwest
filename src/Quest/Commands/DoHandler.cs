using System;
using System.IO;
using System.Collections.Generic;
using Quest.Models;
using System.Linq;

namespace Quest.Commands
{
    public static class DoHandler
    {
        public static int Handle(string[] args)
        {
            try
            {
                string doText = ArgumentsHandler.GetTaskTextFromCommandLineArguments(args, "do");
                App app = ArgumentsHandler.GetAppFromCommandLineArguments(args);
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
