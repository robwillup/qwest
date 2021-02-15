using Quest;
using Quest.Commands;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace QuestTests
{
    public class DoTests
    {
        [Fact]
        public async Task TestHandleAsync()
        {
            //Environment.SetEnvironmentVariable("QUEST_PATH", Path.Combine(Environment.CurrentDirectory));            
            //string[] args = { "do", "test", "-a", "unit-test", "-f", "doCmd" };
            //bool success = await Do.HandleAsync(args);
            //Assert.True(success);
        }
    }
}
