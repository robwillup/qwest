using Quest;
using System.IO;
using Xunit;

namespace QuestTests
{
    public class TodoTests
    {
        [Fact]
        public void TestAdd_PassIfTodoIsAdded()
        {
            ToDoTests toDo = new ToDoTests();
            string expected = "do this";
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "todo.md");
            toDo.Add(expected);
            var actual = File.ReadAllText(filePath);
            File.Delete(filePath);
            Assert.Contains(expected, actual);            
        }

        [Fact]
        public void TestComplete_PassIfTodoHasStrikethrough()
        {
            ToDoTests toDo = new ToDoTests();
            string todo = "do this";
            string expected = "* ~~do this";
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "todo.md");
            toDo.Add(todo);
            toDo.Complete(todo);
            var actual = File.ReadAllText(filePath);
            File.Delete(filePath);
            Assert.Contains(expected, actual);
        }
    }
}
