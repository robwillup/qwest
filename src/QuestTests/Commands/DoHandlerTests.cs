using Quest.Commands;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace QuestTests
{
    public class DoHandlerTests
    {
        [Fact]
        public async Task TestAdd_PassIfTodoIsAdded()
        {            
            string expected = "do this";
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "todo-test.md");
            using (FileStream fileStream = File.Create(filePath))
            {
                fileStream.Write(new byte[0]);
            }
            byte[] content;
            DoHandler.Add(expected, filePath);
            using (FileStream SourceStream = File.Open(filePath, FileMode.Open))
            {
                content = new byte[SourceStream.Length];
                await SourceStream.ReadAsync(content, 0, (int)SourceStream.Length);
            }
            string actual = Encoding.UTF8.GetString(content);
            File.Delete(filePath);
            Assert.Contains(expected, actual);            
        }
    }
}
