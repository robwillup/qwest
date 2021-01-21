using Quest.Data;
using static System.Console;

namespace Quest.IO
{
    public static class Help
    {
        public static int WriteHelpMessage(HelpMessageTypes messageType)
        {
            switch (messageType)
            {
                case HelpMessageTypes.Suggestion:
                    WriteLine(HelpMessages.HelpSuggestion);
                    break;
                default:
                    WriteLine(HelpMessages.CommandHelpMessage);
                    break;
            }
            return 0;
        }
    }
}
