using Quest;
using Quest.Commands;
using Quest.Models;
using Xunit;

namespace QuestTests.Commands
{
    public class ConfigHandlerTests
    {
        [Fact]
        public void TestList_PassIfNotExceptions()
        {
            ConfigHandler.List();
        }

        [Fact]
        public void TestAdd_PassIfAdded()
        {
            string[] args = new string[] { "--name", "test", "--local-path", "here", "--remote", "there" };
            ConfigHandler.Add(args);

            Config config = Setup.GetConfig();
            var predicate = new System.Predicate<App>(a => a.Name == args[1]);
            Assert.Contains(config.Applications, predicate);
            ConfigHandler.Delete(args);
        }

        [Fact]
        public void TestDelete_PassIfDeleted()
        {
            string[] args = new string[] { "--name", "test", "--local-path", "here", "--remote", "there" };
            ConfigHandler.Add(args);
            ConfigHandler.Delete(args);
            Config config = Setup.GetConfig();
            var predicate = new System.Predicate<App>(a => a.Name == args[1]);
            Assert.DoesNotContain(config.Applications, predicate);            
        }
    }
}
