using Quest.Commands;
using System.Threading.Tasks;
using Xunit;

namespace QuestTests
{
    public class DoTests
    {
        [Fact]
        public async Task TestHandleAsync()
        {
            string[] args = { "do", "test", "-a", "unit-test", "-f", "doCmd" };
            bool success = await Do.HandleAsync(args);
            Assert.True(success);
        }
    }
}
