using System.IO;

namespace Quest.Commands
{
    public static class DoRoutines
    {
        public static string TodoText { get; set; }        
        public static int Create(string text, string path)
        {
            PrepareToDoFile(path);
            return DoCreator.AddOne(text, path);
        }

        public static void PrepareToDoFile(string path) 
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                File.Create(path);
            }
            else if (!File.Exists(path))
                File.Create(path);
        }
    }
}
