using System;
using System.IO;
using System.Collections.Generic;
using Quest.Models;
using Quest.IO;
using Quest.ObjectParsers;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Linq;

namespace Quest.Commands
{
    public static class Do
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

        private static bool Add(string doText, string todoPath)
        {
            try
            {
                string todoText = $"* {doText} - ({Guid.NewGuid()}) - Created at: {DateTime.Now}\n";
                FileInfo fi = new FileInfo(todoPath);
                using var sw = fi.Open(FileMode.Append, FileAccess.Write);
                sw.Write(Encoding.ASCII.GetBytes(todoText));
                //File.AppendAllLines(todoPath, lines);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
