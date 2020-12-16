using Quest.Commands;
using System.IO;
using Xunit;

namespace QuestTests
{
    public class TodoTests
    {
        [Fact]
        public void TestAdd_PassIfTodoIsAdded()
        {            
            string expected = "do this";
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "todo.md");
            DoHandler.Add(expected);
            var actual = File.ReadAllText(filePath);
            File.Delete(filePath);
            Assert.Contains(expected, actual);            
        }

        [Fact]
        public void TestComplete_PassIfTodoIsInDoneFile()
        {            
            string todo = "do this :";
            string expected = "* do this";
            string todoPath = Path.Combine(Directory.GetCurrentDirectory(), "todo.md");
            DoHandler.Add(todo);
            DoneHandler.Complete(todo);
            string donePath = Path.Combine(Directory.GetCurrentDirectory(), "done.md");
            var actual = File.ReadAllText(donePath);
            File.Delete(todoPath);
            File.Delete(donePath);
            Assert.Contains(expected, actual.Split(" :")[0]);
        }
    }
}
