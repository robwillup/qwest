using Quest.Commands;
using Xunit;

namespace QuestTests.Commands
{
    public class UndoHandlerTests
    {
        [Fact]
        public void TestUndo_PassIfReturns1()
        {
            string[] args = new string[] { "only one" };
            int actual = UndoHandler.Undo(args);
            Assert.Equal(1, actual);
        }
    }
}
