using Quest.Data.Help;
using static System.Console;

namespace Quest.IO.StdOut
{
    public static class HelpDisplayer
    {
        public static bool WriteHelpMessage(HelpMessageTypes messageType)
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
                case HelpMessageTypes.Dont:
                    WriteLine(HelpMessages.Dont);
                    break;
                case HelpMessageTypes.Configuration:
                    WriteLine(HelpMessages.Config);
                    break;
                case HelpMessageTypes.ConfigAdd:
                    WriteLine(HelpMessages.ConfigAdd);
                    break;
                case HelpMessageTypes.ConfigList:
                    WriteLine(HelpMessages.ConfigList);
                    break;
                case HelpMessageTypes.ConfigRemove:
                    WriteLine(HelpMessages.ConfigRemove);
                    break;
                default:
                    WriteLine(HelpMessages.CommandHelpMessage);
                    break;
            }
            return true;
        }
    }
}
