using Quest;
using System.IO;
using Xunit;

namespace QuestTests.SetupTests
{
    public class SetupTests
    {
        [Fact]
        public void TestShouldCreateConfigFile()
        {
            string[] args = { "version" };            
            bool actual = Setup.ShouldCreateConfigFile(args);
            Assert.False(actual);
        }

        [Fact]
        public void TestGetConfigPath()
        {
            string partialPath = Path.Combine(".quest", "config.yml");
            string actual = Setup.GetConfigPath();
            Assert.Contains(partialPath, actual);
        }
    }
}
