using Quest.Console;
using System.Linq;

namespace Quest.Arguments
{
    public static class DoHandler
    {
        public static string DoCommandHandler(string[] args)
        {
            int doIndex = args.ToList().IndexOf("do");
            if (doIndex + 1 < args.Length && !string.IsNullOrEmpty(args[doIndex + 1]))
                return args[doIndex + 1];

            NewCommandUi.WriteNewCommandError("A text for the 'do' command must be provided.");
            return null;
        }
    }
}
