using Quest.Commands;
using Xunit;

namespace QuestTests.CommandsTests
{
    public class ListDoneTests
    {
        [Fact]
        public void TestHandle_PassIfReturnsTrue()
        {
            string[] args = { "done" };
            bool success = ListDone.Handle(args);
            Assert.True(success);
        }                
    }
}
