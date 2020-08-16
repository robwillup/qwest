using System;
using System.IO;
using System.Text;

namespace Quest
{
    public static class DoCreator
    {
        public static int AddOne(string todo, string todoFilePath, int maxValue = 0)
        {
            StringBuilder stringBuilder = maxValue == 0 ? new StringBuilder() : new StringBuilder(maxValue, maxValue);
            try
            {
                int hashCode = todo.GetHashCode();
                if (string.IsNullOrEmpty(todo))
                    throw new ArgumentNullException("ToDo text is null or empty.");
                stringBuilder.AppendLine($"* [{hashCode}] - {todo}");
                File.AppendAllText(todoFilePath, stringBuilder.ToString());
                return hashCode;
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
