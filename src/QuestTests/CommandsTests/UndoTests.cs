using Quest.Commands;
using System;
using System.Threading.Tasks;
using Xunit;

namespace QuestTests.CommandsTests
{
    public class UndoTests
    {        
        public UndoTests()
        {     
            Environment.SetEnvironmentVariable("QUEST_PATH", Environment.CurrentDirectory);
        }

        [Fact]
        public async Task TestHandle_PassIfReturnsTrue()
        {
            string[] args = { "do", "TestHandle_PassIfReturnsTrue", "-a", "unit-test", "-f", "undo-tests" };
            _ = await Do.HandleAsync(args);
            args[0] = "done";
            _ = await Done.HandleAsync(args);
            args[0] = "undo";
            bool success = Undo.Handle(args);
            Assert.True(success);
        }
    }
}
