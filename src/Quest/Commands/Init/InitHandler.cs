using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Quest.Commands.Init
{
    public static class InitHandler
    {
        public static bool CreateQuestDirectory()
        {
            Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), ".quest"));
            return true;
        }
        public static bool CheckQuest()
        {
            IEnumerable<string> directories = Directory.EnumerateDirectories(Directory.GetCurrentDirectory(), ".quest", SearchOption.TopDirectoryOnly);
            foreach (string dir in directories)
            {
                IEnumerable<string> files = Directory.EnumerateFiles(dir, ".config", SearchOption.TopDirectoryOnly);
                foreach (string file in files)
                {
                    foreach (string line in File.ReadLines(file))
                    {
                        if (line.Contains("quest_path"))
                            return true;
                    }
                }
            }
            return false;
        }
    }
}
