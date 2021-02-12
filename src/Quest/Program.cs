using Quest;
using Quest.IO;

int code = Setup.HandleConfiguration(args);
if (code != 0)
    return code;
string command = CommandLineHandler.ParseArguments(args);
return CommandHandler.Run(args, command);