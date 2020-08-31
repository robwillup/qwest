namespace Quest.Commands
{
    public enum CommandNames
    {        
        Do,   // Creates new task
        Dont, // Deletes a task
        Done, // Marks a task as complete
        ToDo, // Lists tasks
        Feat, // Creates a new feature
        Help, // Displays available options
        Init  // Setup .quest dir in source code
    }

    public static class EnumExtensions
    {
        public static string FormatCommandNames(this CommandNames commandName)
        {
            return commandName.ToString().ToLower();
        }
    }
}
