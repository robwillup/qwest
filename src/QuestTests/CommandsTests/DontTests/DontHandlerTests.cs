using Quest.Commands;
using Xunit;

namespace QuestTests.CommandsTests.DontTests
{
    public class DontHandlerTests
    {
        [Fact]
        public void DeleteToDo_PassIfReturnsTrue()
        {
            // Arrange
            string hash = "";
            // Act
            // Assert
            Assert.True(DontHandler.DeleteTodo(hash));
        }
    }
}
