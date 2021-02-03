using Quest;
using Quest.Commands;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace QuestTests.Commands
{
    public class DontHandlerTests
    {
        [Fact]
        public void TestRemove_PassIfNoTodoFile()
        {
            string[] args = new string[2] { "dont", "quit" };
            int actual = DontHandler.Remove(args);
            Assert.Equal(1, actual);
        }

        [Fact]
        public async Task TestRemove_PassIfNoTasks()
        {
            string file = "todo-testremove-notasks.md";
            await FileHandler.CreateTodoFileAsync(file);
            string[] args = new string[2] { "dont", "quit" };
            int actual = DontHandler.Remove(args);
            File.Delete(file);
            Assert.Equal(1, actual);
        }
    }
}
