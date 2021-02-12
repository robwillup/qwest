using Quest.Models;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quest
{
    public static class FileHandler
    {
        public static int CreateQuestDirInSourcePath(string path)
        {
            if (Directory.Exists(path))
                return 0;
            Directory.CreateDirectory(path);
            return 0;
        }

        public static int CreateFeatureDirInSourcePath(string path)
        {
            if (Directory.Exists(path))
                return 0;
            Directory.CreateDirectory(path);
            return 0;
        }

        public static async Task<string> CreateQuestFilesAsync(App app, bool doneFile = false)
        {
            string file = "todo.md";
            string content = "# To Dos\n\n";
            if (doneFile) 
            {
                file = "done.md";
                content = "# Completed\n\n";
            }            
            string filePath = Path.Combine(app.LocalPath, ".quest", app.Features.First().Name, file);
            DirectoryInfo dir = Directory.GetParent(filePath);
            if (!dir.Exists)
                dir.Create();
            if (!File.Exists(filePath))
            {                
                using TextReader reader = new StreamReader(CreateContentStream(content));
                await File.WriteAllTextAsync(filePath, reader.ReadToEnd());
            }
            return filePath;
        }

        public static Stream CreateContentStream(string content)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(content);
            Stream stream = new MemoryStream(bytes);
            return stream;
        }
    }
}
