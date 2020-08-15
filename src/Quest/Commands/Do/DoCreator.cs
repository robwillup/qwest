using System;
using System.IO;
using System.Text;

namespace Quest
{
    public static class DoCreator
    {
        public static void AddOne(string todo, string todoFilePath, int maxValue = 0)
        {
            StringBuilder stringBuilder = maxValue == 0 ? new StringBuilder() : new StringBuilder(maxValue, maxValue);
            try
            {
                if (string.IsNullOrEmpty(todo))
                    throw new ArgumentNullException("ToDo text is null or empty.");
                stringBuilder.AppendLine($"* {todo}");
                File.AppendAllText(todoFilePath, stringBuilder.ToString());
            }
            catch (ArgumentOutOfRangeException)
            {
                throw;
            }
            catch (ArgumentNullException)
            {
                throw;
            }
            catch (ArgumentException)
            {
                throw;
            }
        }
    }
}
