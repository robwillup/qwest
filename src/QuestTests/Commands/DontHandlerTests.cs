using Quest.Commands;
using Xunit;

namespace QuestTests.Commands
{
    public class DontHandlerTests
    {
        [Fact]
        public void TestRemove_PassIfReturns1()
        {
            string[] args = new string[2] { "dont", "quit" };
            int actual = DontHandler.Remove(args);
            Assert.Equal(1, actual);
        }
    }
}
