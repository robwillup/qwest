using Quest.Console;
using Quest.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace Quest.Arguments
{
    public static class FeatHandler
    {
        public static void HandleFeatArgs(string[] args)
        {
            try
            {
                List<string> argsList = args.ToList();
                if (!args.Contains("create"))
                    throw new ArgumentException("A subcommand must be used with the command 'feat'");
                int createIndex = argsList.IndexOf("create");
                if (createIndex + 1 >= args.Length || string.IsNullOrEmpty(args[createIndex + 1]))
                    throw new ArgumentException("A name must be provided after the subcommand 'create'");
                if (!args.Contains("--desc"))
                    throw new ArgumentException("The '--desc' flag must be used");
                int descIndex = argsList.IndexOf("--desc");
                if (descIndex + 1 >= args.Length || string.IsNullOrEmpty(args[descIndex + 1]))
                    throw new ArgumentException("An argument must be provided for the '--desc' flag");
                CreateFeature(args[createIndex + 1], args[descIndex + 1]);
            }
            catch (ArgumentException ex)
            {
                FeatCommandUi.ShowError(ex.Message);
            }
        }

        private static void CreateFeature(string name, string desc)
        {
            Feature feature = new Feature()
            {
                Name = name,
                Description = desc
            };
            Directory.CreateDirectory($@".quest\{feature.Name}");
            using StreamWriter sw = File.CreateText($@".quest\{feature.Name}\todo.md");
            sw.WriteLine($"# {feature.Name}");
            sw.WriteLine();
            sw.WriteLine(feature.Description);
        }
    }
}
