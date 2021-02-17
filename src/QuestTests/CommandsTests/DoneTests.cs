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
            todoPath = Path.Combine(Environment.CurrentDirectory, ".quest", "doCmd", "todo.md");
            donePath = Path.Combine(Environment.CurrentDirectory, ".quest", "doCmd", "done.md");
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
            string[] todoArgs = { "do", "TestHandleAsync_PassIfReturnsTrue", "-a", "unit-test", "-f", "doneCmd" };
            _ = await Do.HandleAsync(todoArgs);
            string[] doneArgs = { "done", "TestHandleAsync_PassIfReturnsTrue", "-a", "unit-test", "-f", "doneCmd" };
            bool success = await Done.HandleAsync(doneArgs);
            Assert.True(success);
        }
    }
}
