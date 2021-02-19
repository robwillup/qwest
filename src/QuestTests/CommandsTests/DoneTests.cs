using Quest.Commands;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace QuestTests.CommandsTests
{
    public class DoneTests
    {
        public readonly string todoPath;
        public readonly string donePath;

        public DoneTests()
        {
            todoPath = Path.Combine(Environment.CurrentDirectory, ".quest", "done-tests", "todo.md");
            donePath = Path.Combine(Environment.CurrentDirectory, ".quest", "done-tests", "done.md");
            Environment.SetEnvironmentVariable("QUEST_PATH", Environment.CurrentDirectory);
        }

        ~DoneTests()
        {
            File.Delete(todoPath);
            File.Delete(donePath);
        }

        [Fact]
        public async Task TestHandleAsync_PassIfReturnsTrue()
        {
            string[] todoArgs = { "do", "TestHandleAsync_PassIfReturnsTrue", "-a", "unit-test", "-f", "done-tests" };
            _ = await Do.HandleAsync(todoArgs);
            string[] doneArgs = { "done", "TestHandleAsync_PassIfReturnsTrue", "-a", "unit-test", "-f", "done-tests" };
            bool success = await Done.HandleAsync(doneArgs);
            Assert.True(success);
        }

        [Fact]
        public async Task TestHandleAsync_PassIfTaskIsMovedToDone()
        {
            string[] todoArgs = { "do", "TestHandleAsync_PassIfTaskIsMovedToDone", "-a", "unit-test", "-f", "done-tests" };
            _ = await Do.HandleAsync(todoArgs);
            string[] doneArgs = { "done", "TestHandleAsync_PassIfTaskIsMovedToDone", "-a", "unit-test", "-f", "done-tests" };            
            _ = await Done.HandleAsync(doneArgs);
            FileInfo todoFile = new FileInfo(todoPath);
            using StreamReader sr = todoFile.OpenText();
            string content = await sr.ReadToEndAsync();            
            Assert.DoesNotContain("TestHandleAsync_PassIfTaskIsMovedToDone", content);
        }
    }
}
