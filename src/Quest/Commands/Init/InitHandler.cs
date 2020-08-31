using System;
using System.IO;

namespace Quest.Commands.Init
{
    public static class InitHandler
    {
        public static bool CreateQuestDirectory()
        {
            try
            {
                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), ".quest"));
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
