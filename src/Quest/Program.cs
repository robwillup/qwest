using Quest;
using Quest.IO;
using System;
using static System.Console;

try
{
    int code = Setup.HandleConfiguration(args);
    if (code != 0)
        return code;
    string command = CommandLineHandler.ParseArguments(args);
    if (await CommandHandler.RunAsync(args, command))
        return 0;
    return 1;
}
catch (Exception ex)
{
    WriteLine(ex.ToString());
    return 1;
}