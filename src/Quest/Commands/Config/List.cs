using Quest.Models;

namespace Quest.Commands.Config
{
    public static class List
    {
        public static Configuration ListConfig()
        {
            return Setup.GetConfig();            
        }
    }
}
