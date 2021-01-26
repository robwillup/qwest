using Quest.Commands;
using System.IO;
using Xunit;

namespace QuestTests.Commands
{
    public class UndoHandlerTests
    {
        [Fact]
        public void TestUndo_PassIfReturns1()
        {
            string[] args = new string[] { "only one" };
            int actual = UndoHandler.Undo(args);
            Assert.Equal(1, actual);
        }
      
        [Fact]
        public void TestUndo_PassIfNoDoneMDFile()
        {
            string[] args = new string[2] { "undo", "that" };
            int actual = UndoHandler.Undo(args);
            Assert.Equal(1, actual);
        }

        [Fact]
        public void TestUndo_PassIfNoTodoMDFile()
        {
            string[] args = new string[2] { "undo", "that" };
            string path = Path.Combine(Directory.GetCurrentDirectory(), "done-undo-test.md");
            using (File.Create(path)) { };
            int actual = UndoHandler.Undo(args, doneFilePath: path);
            File.Delete(path);
            Assert.Equal(1, actual);
        }

        [Fact]
        public void TestUndo_PassIfNothingInDone()
        {
            string[] args = new string[2] { "undo", "that" };
            string path = Path.Combine(Directory.GetCurrentDirectory(), "done.md");
            using (File.Create(path)) { };
            string todoPath = Path.Combine(Directory.GetCurrentDirectory(), "todo.md");
            using (File.Create(todoPath)) { };
            int actual = UndoHandler.Undo(args, doneFilePath: path, todoFilePath: todoPath);
            File.Delete(path);
            File.Delete(todoPath);
            Assert.Equal(1, actual);
        }
    }
}
