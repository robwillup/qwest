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
            await FileHandler.CreateTodoFileAsync("todo-testremove.md");
            string[] args = new string[2] { "dont", "quit" };
            int actual = DontHandler.Remove(args);
            File.Delete("todo-testremove.md");
            Assert.Equal(1, actual);
        }

        [Fact]
        public async Task TestRemove_PassIfRemovesTask()
        {
            string file = "todo-testremove.md";
            await FileHandler.CreateTodoFileAsync(file);
            DoHandler.Add("test", file);
            int tasksBefore = File.ReadAllLines(file).ToList().Count;
            string[] args = new string[2] { "dont", "test" };
            _ = DontHandler.Remove(args, file);
            int tasksAfter = File.ReadAllLines(file).ToList().Count;
            File.Delete(file);
            Assert.NotEqual(tasksBefore, tasksAfter);
        }
    }
}
