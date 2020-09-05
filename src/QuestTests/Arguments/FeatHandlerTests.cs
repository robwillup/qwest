using Quest.Arguments;
using Xunit;

namespace QuestTests.Arguments
{
    public class FeatHandlerTests
    {
        [Fact]
        public void GetFeature_PassIfNoException()
        {
            // Arrange
            string[] args = new string[] { "feat", "create", "Button", "--desc", "A button" };

            // Act
            // Assert
            FeatHandler.HandleFeatArgs(args);
        }
    }
}
