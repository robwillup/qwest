using System.IO;

namespace Quest.Commands.ToDo
{
    public static class ToDoHandler
    {        
        public static string[] ListToDos(string path)
        {
            return File.ReadAllLines(path);            
        }

        public static byte[] ListToDosAsBytes(string path)
        {
            using FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
            byte[] bytes = new byte[file.Length];
            int numberOfBytesToRead = (int)file.Length;
            int numberOfBytesRead = 0;
            while (numberOfBytesToRead > 0)
            {
                int n = file.Read(bytes, numberOfBytesRead, numberOfBytesToRead);
                if (n == 0)
                    break;
                numberOfBytesRead += n;
                numberOfBytesToRead -= n;
            }
            return bytes;
        }
    }
}
