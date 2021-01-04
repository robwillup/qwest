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
            int actual = ToDoHandler.List();
            Assert.Equal(1, actual);
        }

        [Fact]
        public async Task TestList_PassIfNoTasks()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "todo.md");
            await FileHandler.CreateTodoFileAsync(filePath: path);
            int actual = ToDoHandler.List(path);
            File.Delete(path);
            Assert.Equal(1, actual);
        }

        [Fact]
        public async Task TestList_PassIfThereAreTasks()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "todo.md");
            await FileHandler.CreateTodoFileAsync(filePath: path);
            DoHandler.Add("test", filePath: path);
            int actual = ToDoHandler.List(path);
            File.Delete(path);
            Assert.Equal(0, actual);
        }
    }
}
