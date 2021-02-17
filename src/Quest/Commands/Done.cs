using Quest.IO;
using Quest.Models;
using Quest.ObjectParsers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Quest.Commands
{
    public static class Done
    {
        public static async Task<bool> HandleAsync(string[] args)
        {
            int doneIndex = CommandLineArguments.GetIndexOfFlag(args, "done") + 1;
            if (!CommandLineArguments.IsArgumentValid(args, doneIndex))
                throw new ArgumentException("Missing one or more required arguments. \n Run 'quest help [command]' for more information.");
            string doneText = args[doneIndex];
            App app = AppParser.GetAppWithFeatureFromCommandLineArguments(args);
            string donePath = await FileHandler.CreateQuestFilesAsync(app, doneFile: true);
            string todoPath = await FileHandler.CreateQuestFilesAsync(app);
            return Complete(doneText, donePath, todoPath);
        }

        private static bool Complete(string todoText, string donePath, string todoPath)
        {            
            List<string> lines = File.ReadAllLines(todoPath).ToList();
            string line = lines.Find(t => t.Contains(todoText));            
            if (string.IsNullOrEmpty(line))
                return true;
            lines.Remove(line);
            File.WriteAllLines(todoPath, lines);
            File.AppendAllText(donePath, $"{line} - Completed at: {DateTime.Now}\n");
            return true;
        }
    }
}
