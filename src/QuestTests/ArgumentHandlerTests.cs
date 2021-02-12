using Quest;
using Xunit;

namespace QuestTests
{
    public class ArgumentHandlerTests
    {
        [Fact]
        public void TestAnyArgument_PassIfReturnsTrue()
        {            
            bool actual = CommandLineHandler.AnyArgument(new string[1] { "one" });
            Assert.True(actual);
        }

        [Fact]
        public void TestAnyArgument_PassIfReturnsFalse()
        {
            bool actual = CommandLineHandler.AnyArgument(new string[0]);
            Assert.False(actual);
        }

        [Fact]
        public void TestGetCommand()
        {
            string[] args = new string[3] { "do", "todo", "done" };
            string expected = "do";
            string actual = CommandLineHandler.GetCommand(args);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestHasFlag_PassWhenTrue()
        {
            string flag = "--test";
            string[] args = new string[3] { "do", "this", "--test" };
            bool result = CommandLineHandler.HasFlag(args, flag);
            Assert.True(result);
        }

        [Fact]
        public void TestHasFlag_PassWhenFalse()
        {
            string flag = "--feat";
            string[] args = new string[3] { "do", "this", "--test" };
            bool result = CommandLineHandler.HasFlag(args, flag);
            Assert.False(result);
        }

        [Fact]
        public void TestGetIndexOfFlag()
        {
            int expected = 2;
            string flag = "--feat";
            string[] args = new string[3] { "do", "this", "--feat" };
            int index = CommandLineHandler.GetIndexOfFlag(args, flag);
            Assert.Equal(expected, index);
        }
    }
}
