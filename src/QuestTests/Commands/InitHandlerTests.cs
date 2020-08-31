using Quest.Commands.Init;
using System.IO;
using Xunit;

namespace QuestTests.Commands
{
    public class InitHandlerTests
    {
        [Fact]
        public void TestCreateQuestDirectory_PassWhenReturnsTrue()
        {
            // Arrange
            // Act
            // Assert
            Assert.True(InitHandler.CreateQuestDirectory());
            // Clean up
            Directory.Delete(Path.Combine(Directory.GetCurrentDirectory(), ".quest"));
        }
    }
}
