using System;
using System.IO;

namespace Quest.Files
{
    public class QuestFile : IQuestFile
    {
        public bool Create(string path)
        {
            try
            {
                if (File.Exists(path))
                    throw new ArgumentException("File already exists");
                using var fs = File.Create(path);
                return File.Exists(path);
            }
            catch (ArgumentException)
            {
                throw;
            }
        }

        public bool Delete(string path) 
        {
            try
            {
                if (!File.Exists(path))
                    throw new ArgumentException("Could not find the file");
                File.Delete(path);
                return !File.Exists(path);
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (DirectoryNotFoundException)
            {
                throw;
            }
            catch (IOException)
            {
                throw;
            }
        }
    }
}
