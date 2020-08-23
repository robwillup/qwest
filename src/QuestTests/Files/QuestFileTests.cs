using Quest.Files;
using System;
using System.IO;
using Xunit;

namespace QuestTests
{
    public class QuestFileTests
    {
        [Fact]
        public void CreateTest_PassIfReturnsTrue()
        {
            // Arrange
            string file = "fileCreation.md";
            IQuestFile quest = new QuestFile();
            if (File.Exists(file))
                File.Delete(file);
            // Act
            bool result = quest.Create(file);
            // Assert
            Assert.True(result);

            // Clean up
            if (result)
                File.Delete(file);
        }

        [Fact]
        public void CreateTest_PassIfThrowsArgumentException()
        {
            // Arrange
            string file = "AlreadyExistis.txt";
            FileStream fs = File.Create(file);
            IQuestFile quest = new QuestFile();

            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => quest.Create(file));

            // Clean up
            fs.Dispose();
            File.Delete(file);
        }

        [Fact]
        public void DeleteTest_PassIfReturnsTrue()
        {
            // Arrange
            string file = "toBeDeleted";
            if (File.Exists(file))
                File.Delete(file);
            IQuestFile quest = new QuestFile();
            quest.Create(file);

            // Act
            bool result = quest.Delete(file);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void DeleteTest_PassIfThrowsArgumentException() 
        {
            // Arrange
            string file = "doesNoExist.txt";
            IQuestFile quest = new QuestFile();

            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => quest.Delete(file));
        }
    }
}
