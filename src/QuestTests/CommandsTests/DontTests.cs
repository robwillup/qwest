using Quest.Commands;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace QuestTests.CommandsTests
{
    public class DontTests
    {
        public readonly string todoPath;
        public DontTests()
        {
            todoPath = Path.Combine(Environment.CurrentDirectory, ".quest", "dont-tests", "todo.md");            
            Environment.SetEnvironmentVariable("QUEST_PATH", Environment.CurrentDirectory);
        }

        [Fact]
        public async Task TestHandleAsync_PassWhenReturnsTrue()
        {
            string[] todoArgs = { "do", "TestHandleAsync_PassWhenReturnsTrue", "-a", "unit-test", "-f", "dont-tests" };
            _ = await Do.HandleAsync(todoArgs);
            string[] dontArgs = { "dont", "TestHandleAsync_PassWhenReturnsTrue", "-a", "unit-test", "-f", "dont-tests" };
            bool success = await Dont.HandleAsync(dontArgs);
            Assert.True(success);
        }

        [Fact]
        public async Task TestHandleAsync_PassWhenTodoIsDeleted()
        {
            string[] todoArgs = { "do", "TestHandleAsync_PassWhenReturnsTrue", "-a", "unit-test", "-f", "dont-tests" };
            _ = await Do.HandleAsync(todoArgs);
            string[] dontArgs = { "dont", "TestHandleAsync_PassWhenReturnsTrue", "-a", "unit-test", "-f", "dont-tests" };
            _ = await Dont.HandleAsync(dontArgs);
            FileInfo todoFile = new FileInfo(todoPath);
            using StreamReader sr = todoFile.OpenText();
            string content = await sr.ReadToEndAsync();
            Assert.DoesNotContain("TestHandleAsync_PassIfTaskIsMovedToDone", content);
        }
    }
}
