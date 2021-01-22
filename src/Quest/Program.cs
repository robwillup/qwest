using Quest;
int code = Setup.HandleConfiguration(args);
if (code != 0)
    return code;
return await ArgumentsHandler.HandleAsync(args);