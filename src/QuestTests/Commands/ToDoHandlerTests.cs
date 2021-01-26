using Quest;
using Quest.Commands;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace QuestTests.Commands
{
    public class ToDoHandlerTests
    {
        [Fact]
        public void TestList_PassIfNoFile()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            int actual = ToDoHandler.List(path);
            Assert.Equal(1, actual);
        }

        [Fact]
        public async Task TestList_PassIfNoTasks()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "todo-test-list.md");
            await FileHandler.CreateTodoFileAsync(path);
            int actual = ToDoHandler.List(path);
            File.Delete(path);
            Assert.Equal(1, actual);
        }
    }
}
