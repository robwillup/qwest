using Quest;
using Quest.IO;
using System;
using static System.Console;

try
{
    if (!Setup.HandleConfiguration(args))
        return 1;
    string command = CommandLineHandler.ParseArguments(args);
    if (await CommandHandler.RunAsync(args, command))
        return 0;
    return 1;
}
catch (Exception ex)
{
    WriteLine(ex.Message);
    return 1;
}