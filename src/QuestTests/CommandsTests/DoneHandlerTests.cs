using Quest.Commands;
using Xunit;

namespace QuestTests
{
    public class DoneHandlerTests
    {
        [Fact]
        public void TestListDone_PassIfReturns1()
        {
            int returnValue = DoneHandler.ListDone();
            Assert.Equal(1, returnValue);
        }
    }
}
