using Quest;
using Quest.IO;

int code = Setup.HandleConfiguration(args);
if (code != 0)
    return code;
string command = CommandLineHandler.ParseArguments(args);
if (await CommandHandler.RunAsync(args, command))
    return 0;
return 1;