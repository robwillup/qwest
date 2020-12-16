using System.IO;
using System.Threading.Tasks;

namespace Quest
{
    public static class FileHandler
    {
        public static async Task<int> CreateTodoFile(string fileName = "todo.md")
        {
            string todoPath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
            if (!File.Exists(todoPath)) 
            {
                await File.WriteAllTextAsync(todoPath, "# To Dos\n\n");                
            }
                
            return 0;
        }
    }
}
