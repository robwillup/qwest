namespace Quest
{
    static class HelpMessages
    {
        public static string CommandHelpMessage { get; set; } = @"
Quest!

COMMANDS:
    do.............Creates a new task
    done...........Lists completed tasks
    done...........Marks the task as complete
    todo...........Lists current active tasks
    undo...........Marks a complete task as active
    version........Displays current version
    help...........Displays information about commands and flags

Use 'quest help <COMMAND>' for more information.";
    }
}
