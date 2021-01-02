using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Quest
{
    public static class FileHandler
    {
        public static async Task<int> CreateTodoFileAsync(string fileName = "todo.md", string filePath = "")
        {
            if (string.IsNullOrEmpty(filePath))
                filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
            if (!File.Exists(filePath))
            {
                await File.WriteAllTextAsync(filePath, "# To Dos\n\n");
                using (TextReader reader = new StreamReader(CreateContentStream("# To Dos\n\n")))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                        await File.WriteAllTextAsync(filePath, line);
                }
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
