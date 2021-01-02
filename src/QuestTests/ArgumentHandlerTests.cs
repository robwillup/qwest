using Quest;
using Xunit;

namespace QuestTests
{
    public class ArgumentHandlerTests
    {
        [Fact]
        public void TestAnyArgument_PassIfReturnsTrue()
        {            
            bool actual = ArgumentsHandler.AnyArgument(new string[1] { "one" });
            Assert.True(actual);
        }

        [Fact]
        public void TestAnyArgument_PassIfReturnsFalse()
        {
            bool actual = ArgumentsHandler.AnyArgument(new string[0]);
            Assert.False(actual);
        }
    }
}
