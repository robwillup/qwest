using Quest;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace QuestTests
{
    public class FileHandlerTests
    {
        [Fact]
        public async Task TestCreateToDoFile()
        {
            string file = Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.UserProfile), "todo.md");
            await FileHandler.CreateTodoFileAsync("todo.md", file);
            Assert.True(File.Exists(file));
            File.Delete(file);
        }

        [Fact]
        public void TestCreateContentStream()
        {
            string expectedString = "Hello Quest";            
            MemoryStream contentStream = (MemoryStream)FileHandler.CreateContentStream(expectedString);
            string actualString = Encoding.UTF8.GetString(contentStream.ToArray());
            Assert.Equal(expectedString, actualString);

        }
    }
}
