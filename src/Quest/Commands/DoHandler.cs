using System;
using System.IO;
using System.Collections.Generic;
using Quest.Models;
using Quest.IO;
using Quest.ObjectParsers;
using System.Threading.Tasks;

namespace Quest.Commands
{
    public static class DoHandler
    {
        public static async Task<bool> HandleAsync(string[] args)
        {
            try
            {
                int doTextIndex = CommandLineArguments.GetIndexOfFlag(args, "do") + 1;
                if (!CommandLineArguments.IsArgumentValid(args, doTextIndex))
                    throw new ArgumentException("Missing one or more required arguments. \n Run 'quest help [command]' for more information.");
                string doText = args[doTextIndex];
                App app = AppParser.GetAppWithFeatureFromCommandLineArguments(args);
                return Add(doText, await FileHandler.CreateQuestFilesAsync(app));
            }
            catch (Exception)
            {                
                throw;
            }
        }

        public static bool Add(string doText, string todoPath)
        {
            try
            {
                string todoText = $"* {doText} - ({Guid.NewGuid()}) - Created at: {DateTime.Now}";
                List<string> lines = new List<string>() { todoText };                
                File.AppendAllLines(todoPath, lines);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
