using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Quest
{
    public static class FileHandler
    {
        public static async Task<int> CreateTodoFileAsync(string file = "")
        {   
            if (string.IsNullOrEmpty(file))
                file = Path.Combine(Directory.GetCurrentDirectory(), "todo.md");
            if (!File.Exists(file))
            {                
                using TextReader reader = new StreamReader(CreateContentStream("# To Dos\n\n"));
                await File.WriteAllTextAsync(file, reader.ReadToEnd());
            }
            return 0;
        }

        public static Stream CreateContentStream(string content)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(content);
            Stream stream = new MemoryStream(bytes);
            return stream;
        }
    }
}
