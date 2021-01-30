using Quest.Data.Help;
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
                case HelpMessageTypes.Do:
                    WriteLine(HelpMessages.Do);
                    break;
                case HelpMessageTypes.Done:
                    WriteLine(HelpMessages.Done);
                    break;
                case HelpMessageTypes.Todo:
                    WriteLine(HelpMessages.Todo);
                    break;
                case HelpMessageTypes.Undo:
                    WriteLine(HelpMessages.Undo);
                    break;
                default:
                    WriteLine(HelpMessages.CommandHelpMessage);
                    break;
            }
            return 0;
        }
    }
}
