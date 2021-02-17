using Quest.Commands;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace QuestTests
{
    public class DoTests
    {
        private readonly string todoPath;
        public DoTests()
        {
            todoPath = Path.Combine(Environment.CurrentDirectory, ".quest", "doCmd", "todo.md");
            Environment.SetEnvironmentVariable("QUEST_PATH", Environment.CurrentDirectory);
        }

        ~DoTests()
        {
            File.Delete(todoPath);
        }

        [Fact]
        public async Task TestHandleAsync_PassIfReturnsTrue()
        {            
            string[] args = { "do", "TestHandleAsync_PassIfReturnsTrue", "-a", "unit-test", "-f", "doCmd" };
            bool success = await Do.HandleAsync(args);            
            Assert.True(success);
        }

        [Fact]
        public async Task TestHandleAsync_PassIfTaskIsCreated()
        {
            string task = "TestHandleAsync_PassIfTaskIsCreated";
            string[] args = { "do", task, "-a", "unit-test", "-f", "doCmd" };
            _ = await Do.HandleAsync(args);
            FileInfo file = new FileInfo(todoPath);
            using StreamReader sr = new StreamReader(file.OpenRead());
            string content = await sr.ReadToEndAsync();            
            Assert.Contains(task, content);
        }

        [Fact]
        public async Task TestHandleAsync_PassIfException()
        {
            string task = "TestHandleAsync_PassIfException";
            string[] args = { "do", task, "-a", "unit-test" };
            await Assert.ThrowsAsync<ArgumentException>(async () => await Do.HandleAsync(args));
        }
    }
}
