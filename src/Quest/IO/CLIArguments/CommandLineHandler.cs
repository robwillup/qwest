using Quest.Data.Help;
using Quest.IO.StdOut;
using System;

namespace Quest.IO.CLIArguments
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
                HelpDisplayer.WriteHelpMessage(HelpMessageTypes.Suggestion);
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }        
    }
}
