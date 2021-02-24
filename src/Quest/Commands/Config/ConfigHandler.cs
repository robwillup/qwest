using Quest.Data.Help;
using Quest.IO;
using System;

namespace Quest.Commands.Config
{
    public static class ConfigHandler
    {
        public static bool Handle(string[] args)
        {
            try
            {
                if (args.Length < 2)
                    return HelpDisplayer.WriteHelpMessage(HelpMessageTypes.Default);
                switch (args[1]) 
                {
                    case "list":
                        ConfigDisplayer.DisplayConfig(List.ListConfig());
                        break;
                    case "add":
                        Add.AddApp(args);
                        break;
                    case "rm":
                        Delete.DeleteApp(args);
                        break;
                    default:
                        HelpDisplayer.WriteHelpMessage(HelpMessageTypes.Default);
                        break;
                }                       
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
