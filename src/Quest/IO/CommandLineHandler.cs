using System;
using Quest.Data.Help;

namespace Quest.IO
{
    public static class CommandLineHandler
    {
        public static string ParseArguments(string[] args)
        {
            try
            {
                if (!CommandLineArguments.AnyArgument(args))
                    throw new ArgumentNullException();
                return CommandLineArguments.GetCommand(args);                
            }
            catch (ArgumentNullException)
            {
                Help.WriteHelpMessage(HelpMessageTypes.Suggestion);
                return null;
            }
            catch (Exception ex)
            {
                ErrorHandler.PrintMessage(ex.Message);
                return null;
            }
        }        
    }
}
