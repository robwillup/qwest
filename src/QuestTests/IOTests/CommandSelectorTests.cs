﻿using Quest;
using Xunit;

namespace QuestTests.IOTests
{
    public class CommandSelectorTests
    {
        [Fact]
        public void TestRun()
        {
            string[] args = { "version" };
            string command = "version";
            int actual = CommandHandler.Run(args, command);
            Assert.Equal(0, actual);
        }
    }
}
