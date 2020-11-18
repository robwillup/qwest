using System.IO;
namespace Quest
{
    public static class UndoHandler
    {
        public static void Undo(string todoText) 
        {
            string donePath = Path.Combine(Directory.GetCurrentDirectory(), "done.md");
            if (!File.Exists(donePath))
                return;
            string todoPath = Path.Combine(Directory.GetCurrentDirectory(), "todo.md");

        }
    }
}
