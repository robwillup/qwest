using System;
using System.Collections.Generic;
using System.Linq;
using Quest.Data.Help;
using Quest.IO;
using Quest.Models;

namespace Quest
{
    public static class ArgumentsHandler
    {
        public static int Handle(string[] args)
        {
            try
            {
                if (!AnyArgument(args))
                    return Help.WriteHelpMessage(HelpMessageTypes.Suggestion);
                string command = GetCommand(args);
                return CommandSelector.Run(args, command);
            }
            catch (System.Exception ex)
            {
                ErrorHandler.PrintMessage(ex.ToString());
                return 1;
            }
        }

        public static bool AnyArgument(string[] args) => args.Length > 0;
        public static string GetCommand(string[] args) => args[0];
        public static bool HasFlag(string[] args, string flag)
        {
            foreach (string arg in args)
            {
                if (arg == flag)
                    return true;
            }           
            return false;
        }
        public static int GetIndexOfFlag(string[] args, string flag) => args.ToList().IndexOf(flag);

        public static string GetTaskTextFromCommandLineArguments(string[] args, string command)
        {
            int taskIndex = GetIndexOfFlag(args, command) + 1;
            if (string.IsNullOrEmpty(args[taskIndex]))
                throw new ArgumentException("Missing one or more required arguments. \n Run 'quest help [command]' for more information.");
            if (string.IsNullOrWhiteSpace(args[taskIndex]))
                throw new ArgumentException("Missing one or more required arguments. \n Run 'quest help [command]' for more information.");
            return args[taskIndex];
        }

        public static App GetAppFromCommandLineArguments(string[] args)
        {
            if (!HasFlag(args, "--app") || !HasFlag(args, "--feature"))
                throw new ArgumentException("Missing one or more required arguments. \n Run 'quest help [command]' for more information.");

            int appIndex = GetIndexOfFlag(args, "--app") + 1;
            int featureIndex = GetIndexOfFlag(args, "--feature") + 1;

            if (string.IsNullOrEmpty(args[appIndex]) || string.IsNullOrEmpty(args[featureIndex]))
                throw new ArgumentException("Missing one or more required arguments. \n Run 'quest help [command]' for more information.");
            if (string.IsNullOrWhiteSpace(args[appIndex]) || string.IsNullOrWhiteSpace(args[featureIndex]))
                throw new ArgumentException("Missing one or more required arguments. \n Run 'quest help [command]' for more information.");

            App app = new App()
            {
                Name = args[appIndex],
                Features = new List<Feature>() { new Feature() { Name = args[featureIndex] } }
            };

            Config conf = Setup.GetConfig();

            if (conf.Applications == null || conf.Applications.Count == 0)
                throw new Exception("Please, run 'quest help config add' to learn how to create an application for Quest.");
            if (!conf.Applications.Any(a => a.Name == app.Name))
                throw new ArgumentException($"App '{app.Name}' not found.\n Please, run 'quest help config add' to learn how to add a new app.");

            bool? hasFeature = conf.Applications?.FirstOrDefault(a => a.Name == app.Name)
                                    .Features?.Any(f => f.Name == app.Features.First().Name);

            if (hasFeature == null || hasFeature == false)
            {
                conf.Applications.FirstOrDefault(a => a.Name == app.Name)
                    .Features = new List<Feature>() { new Feature() { Name = app.Features.First().Name } };
                YamlHandler.Update(Setup.GetConfigPath(), conf);
            }

            app.LocalPath = conf.Applications.FirstOrDefault(a => a.Name == app.Name).LocalPath;
            return app;
        }
    }
}
