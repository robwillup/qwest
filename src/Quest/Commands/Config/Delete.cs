using Quest.IO.CLIArguments;
using System;
using System.Linq;

namespace Quest.Commands.Config
{
    internal static class Delete
    {
        internal static int DeleteApp(string[] args)
        {
            if (!CommandLineArguments.HasFlag(args, "--name"))
                throw new ArgumentException("Missing required argument: '--name'");
            string name = args[CommandLineArguments.GetIndexOfFlag(args, "--name") + 1];
            var conf = Setup.GetConfig();
            conf.Applications.Remove(conf.Applications.FirstOrDefault(e => e.Name == name));
            YamlHandler.Update(Setup.GetConfigPath(), conf);
            return 0;
        }
    }
}
