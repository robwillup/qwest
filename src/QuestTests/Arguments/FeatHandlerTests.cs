using Quest.Arguments;
using Quest.Models;
using Xunit;

namespace QuestTests.Arguments
{
    public class FeatHandlerTests
    {
        [Fact]
        public void GetFeature_PassIfReturnsFeature()
        {
            // Arrange
            string[] args = new string[] { "feat", "create", "Button", "--path", ".", "--desc", "A button" };

            // Act
            Feature feature = FeatHandler.GetFeature(args);

            // Assert
            Assert.NotNull(feature);
        }

        [Fact]
        public void GetFeature_PassIfReturnsNull()
        {
            // Arrange
            string[] args = new string[] { "feat", "create", "Button" };

            // Act
            Feature feature = FeatHandler.GetFeature(args);

            // Assert
            Assert.Null(feature);
        }
    }
}
