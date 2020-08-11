using Quest;
using System;
using System.IO;
using Xunit;

namespace QuestTests
{
    public class NewCmdTests
    {
        [Fact]
        public void AddOne_PassIfWritesToFile()
        {
            // Arrange
            string content = "create meaninful tests";
            string expected = "* create meaninful tests\r\n";
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "test.md");
            using (FileStream fileStream = File.Create(filePath)) { };

            // Act
            ToDoCreator.AddOne(content, filePath);
            string actualContent = File.ReadAllText(filePath);

            // Assert
            Assert.Equal(expected, actualContent);

            // Clean up
            File.Delete(filePath);
        }

        [Fact]
        public void AddOne_PassIfThrowsArgumentOutOfRangeException()
        {
            // Arrange
            string content = "t";
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "test.md");
            int maxValue = 4;            

            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => ToDoCreator.AddOne(content, filePath, maxValue));
        }

        [Fact]
        public void AddOne_PassIfThrowsArgumentNullException()
        {
            // Arrange
            string nullPath = null;
            string nullTodo = null;

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => ToDoCreator.AddOne(nullTodo, "path"));
            Assert.Throws<ArgumentNullException>(() => ToDoCreator.AddOne("test", nullPath));
        }

        [Fact]
        public void AddOne_PassIfThrowsArgumentException()
        {
            // Arrange
            string invalidPath = "";
            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => ToDoCreator.AddOne("test", invalidPath));
        }
    }
}
