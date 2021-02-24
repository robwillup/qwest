using Quest.IO;
using Quest.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Quest.ObjectParsers
{
    public static class AppParser
    {
        public static bool IsAppInConfig(App app)
        {
            Configuration conf = Setup.GetConfig();
            if (conf.Applications == null || conf.Applications.Count == 0)
                return false;
            if (!conf.Applications.Any(a => a.Name == app.Name))
                return false;
            return true;
        }

        public static string CreateAppPath(App app)
        {
            Configuration conf = Setup.GetConfig();
            return conf.Applications.FirstOrDefault(a => a.Name == app.Name).LocalPath;
        }

        private static string CreateAppFeaturePath(App app)
        {
            Configuration conf = Setup.GetConfig();
            bool? hasFeature = conf.Applications?.FirstOrDefault(a => a.Name == app.Name)
                                    .Features?.Any(f => f.Name == app.Features.First().Name);

            if (hasFeature == null || hasFeature == false)
            {
                conf.Applications.FirstOrDefault(a => a.Name == app.Name)
                    .Features = new List<Feature>() { new Feature() { Name = app.Features.First().Name } };
                YamlHandler.Update(Setup.GetConfigPath(), conf);
            }
            return conf.Applications.FirstOrDefault(a => a.Name == app.Name).LocalPath;
        }

        public static  App GetAppFromCommandLineArguments(string[] args)
        {
            int appI = CommandLineArguments.GetIndexOfFlag(args, CommandLineArguments.GetAliasOrArgument(args, "--app", "-a")) + 1;            

            if (!CommandLineArguments.IsArgumentValid(args, appI))
                throw new ArgumentException("Missing one or more required arguments. \n Run 'quest help [command]' for more information.");

            App app = new App() { Name = args[appI] };

            if (!IsAppInConfig(app))
                throw new ArgumentException($"App '{app.Name}' not found.\n Please, run 'quest help config add' to learn how to add a new app.");

            app.LocalPath = CreateAppPath(app);
            return app;
        }

        public static App GetAppWithFeatureFromCommandLineArguments(string[] args)
        {
            int appI = CommandLineArguments.GetIndexOfFlag(args, CommandLineArguments.GetAliasOrArgument(args, "--app", "-a")) + 1;
            int featI = CommandLineArguments.GetIndexOfFlag(args, CommandLineArguments.GetAliasOrArgument(args, "--feature", "-f")) + 1;

            if (!CommandLineArguments.IsArgumentValid(args, appI, featI))
                throw new ArgumentException("Missing one or more required arguments. \n Run 'quest help [command]' for more information.");

            App app = new App() { Name = args[appI], Features = new List<Feature>() { new Feature() { Name = args[featI] }}};

            if (!IsAppInConfig(app))
                throw new ArgumentException($"App '{app.Name}' not found.\n Please, run 'quest help config add' to learn how to add a new app.");

            app.LocalPath = CreateAppFeaturePath(app);
            return app;
        }
    }
}
