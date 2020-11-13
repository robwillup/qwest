namespace Quest
{
    static class HelpMessages
    {
        public static string CommandHelpMessage { get; set; } = @"
Quest!

COMMANDS:
    do..........Creates a new task
    done........Marks the task as complete
    todo........Lists current active tasks
    undo........Marks a complete task as active
    version.....displays current version
    help........displays information about commands and flags";
    }
}
