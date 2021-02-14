using Quest.IO;
using Quest.Models;
using System;
using System.Linq;

namespace Quest.Commands
{
    public static class Config
    {
        public static int Handle(string[] args)
        {
            try
            {
                if (args.Length > 1)
                {
                    if (args[1] == "list")
                        List();
                    else if (args[1] == "add")
                        Add(args);
                    else if (args[1] == "rm")
                        Delete(args);
                }
                else
                {
                    string[] helpArgs = new string[2] { "help", "config" };
                    Help.HandleHelp(helpArgs);
                    return 1;
                }
                return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int List()
        {
            ConfigDisplayer.DisplayConfig(Setup.GetConfig());
            return 0;
        }

        public static int Add(string[] args)
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

        public static int Delete(string[] args)
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
