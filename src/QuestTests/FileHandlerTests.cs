using Quest;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace QuestTests
{
    public class FileHandlerTests
    {
        [Fact]
        public async Task TestCreateToDoFile()
        {
            await FileHandler.CreateTodoFileAsync();
            string file = Path.Combine(Directory.GetCurrentDirectory(), "todo.md");
            Assert.True(File.Exists(file));
            File.Delete(file);
        }
    }
}
