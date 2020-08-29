using Quest.Console;
using System.Linq;

namespace Quest.Arguments
{
    public static class DoHandler
    {
        public static string DoCommandHandler(string[] args)
        {
            if (!args.Contains("--feat"))
            {
                DoCommandUi.WriteNewCommandError("The '--feat' flag must be specified.");
                return null;
            }
            int doIndex = args.ToList().IndexOf("do");
            if (doIndex + 1 < args.Length && !string.IsNullOrEmpty(args[doIndex + 1]))
                return args[doIndex + 1];

            DoCommandUi.WriteNewCommandError("A text for the 'do' command must be provided.");
            return null;
        }
    }
}
