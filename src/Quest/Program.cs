using Quest;
using Quest.IO;

int code = Setup.HandleConfiguration(args);
if (code != 0)
    return code;
string command = CommandLineHandler.ParseArguments(args);
if (CommandHandler.Run(args, command) == false)
    return 1;
return 0;