using Quest.Models;

namespace Quest.Commands.Config
{
    internal static class List
    {
        internal static Configuration ListConfig()
        {
            return Setup.GetConfig();            
        }
    }
}
