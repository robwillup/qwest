namespace Quest.Data.Help
{
    static class HelpMessages
    {
        public static string CommandHelpMessage { get; set; } = @"
Quest!

COMMANDS:
    do.............Creates a new task
    done...........Lists completed tasks
    done <GUID>....Marks the task as complete
    todo...........Lists current active tasks
    undo...........Marks a complete task as active
    dont...........Deletes a task from ToDos
    config.........View and edit Quest settings
    version........Displays current version
    help...........Displays information about commands and flags

Use 'quest help <COMMAND>' for more information.";

        public static string HelpSuggestion { get; set; } = @"
Welcome to Quest!
Try using 'help' to see available commands.

Example:
    quest help
";

        public static string Do { get; set; } = @"
Adds a new task to the 'todo.md' file.

Arguments:
    --app
        This is the name of the application the new task refers to. 
        It is defined in the '.quest/config.yml' file.

    --feature
        This is the name of the feature the new task refers to.
        It is defined in the '.quest/config.yml' file.

Example:
    quest do <TASK_TEXT> --app <APP_NAME> --feature <FEATURE_NAME>
";

        public static string Done { get; set; } = @"

When used without a task string, this commands lists the content of the done.md file
When used with a task string, this comment moves a task from the 'todo.md' to the 'done.md' file.

Arguments:
    --app
        This is the name of the application the task refers to. 
        It is defined in the '.quest/config.yml' file.

    --feature
        This is the name of the feature the task refers to.
        It is defined in the '.quest/config.yml' file.

Example:
    quest done --app <APP_NAME> --feature<FEATURE_NAME>
    quest done <UNIQUE_PART_OF_TASK_STRING> --app <APP_NAME> --feature <FEATURE_NAME>
";

        public static string Todo { get; set; } = @"

This commands lists the content of the todo.md file

Arguments:
    --app
        This is the name of the application the task refers to. 
        It is defined in the '.quest/config.yml' file.

    --feature
        This is the name of the feature the task refers to.
        It is defined in the '.quest/config.yml' file.

Example:
    quest todo --app <APP_NAME> --feature<FEATURE_NAME>
";

        public static string Undo { get; set; } = @"

This commands moves a task from 'done.md' to 'todo.md'.

Arguments:
    --app
        This is the name of the application the task refers to. 
        It is defined in the '.quest/config.yml' file.

    --feature
        This is the name of the feature the task refers to.
        It is defined in the '.quest/config.yml' file.

Example:
    quest undo <UNIQUE_PART_OF_TASK_STRING> --app <APP_NAME> --feature<FEATURE_NAME>
";

        public static string Dont { get; set; } = @"

This commands deletes a task from the 'todo.md' file.

Arguments:
    --app
        This is the name of the application the task refers to. 
        It is defined in the '.quest/config.yml' file.

    --feature
        This is the name of the feature the task refers to.
        It is defined in the '.quest/config.yml' file.

Example:
    quest undo <UNIQUE_PART_OF_TASK_STRING> --app <APP_NAME> --feature<FEATURE_NAME>
";

        public static string Config { get; set; } = @"
View and edit Quest settings

Examples:
    quest config list
    quest config add --name my-app
";
    }
}
