using Quest.IO;
using Quest.Models;
using System;

namespace Quest.Commands.Config
{
    public static class Add
    {
        public static int AddApp(string[] args)
        {
            if (!CommandLineArguments.HasFlag(args, "--name"))
                throw new ArgumentException("Missing required argument: '--name'");
            if (!CommandLineArguments.HasFlag(args, "--local-path"))
                throw new ArgumentException("Missing required argument: '--local-path'");
            if (!CommandLineArguments.HasFlag(args, "--remote"))
                throw new ArgumentException("Missing required argument: '--remote'");
            int ni = CommandLineArguments.GetIndexOfFlag(args, "--name") + 1;
            int lpi = CommandLineArguments.GetIndexOfFlag(args, "--local-path") + 1;
            int ri = CommandLineArguments.GetIndexOfFlag(args, "--remote") + 1;
            App app = new App() { Name = args[ni], LocalPath = args[lpi], Remote = args[ri] };
            var conf = Setup.GetConfig();
            conf.Applications.Add(app);
            YamlHandler.Update(Setup.GetConfigPath(), conf);
            return 0;
        }
    }
}
