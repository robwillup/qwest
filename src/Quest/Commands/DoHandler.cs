using System;
using static System.Console;
using System.IO;
using System.Collections.Generic;

namespace Quest.Commands
{
    public static class DoHandler
    {
        public static int Add(string todoText, string fileName = "todo.md", string filePath = "")
        {
            if (string.IsNullOrEmpty(todoText) || string.IsNullOrWhiteSpace(todoText))
            {
                WriteLine("The 'do' command requires at least one argument.");
                return 1;
            }
            var guid = Guid.NewGuid();
            if (string.IsNullOrEmpty(filePath))
                filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
            else if (!Path.HasExtension(filePath))
                filePath = Path.Combine(filePath, fileName);

                todoText = $"* {todoText} - ({guid}) - Created at: {DateTime.Now}";
            List<string> lines = new List<string>() { todoText};
            File.AppendAllLines(filePath, lines);
            return 0;
        }

        public static string Handle(string[] args)
        {            
            string source = GetSource(args);
            string feature = GetFeature(args);
            string doText = GetDo(args);
            return doText;
        }

        public static string GetDo(string[] args)
        {
            string doText = string.Empty;
            int indexOfDo = ArgumentsHandler.GetIndexOfFlag(args, "do");    
            if (args.Length > 1)
                doText = args[indexOfDo + 1];
            return doText;            
        }

        public static string GetSource(string[] args)
        {
            string source = string.Empty;
            int indexOfSource = 0;
            if (ArgumentsHandler.HasFlag(args, "--source"))
                indexOfSource = ArgumentsHandler.GetIndexOfFlag(args, "--source");
            else if (ArgumentsHandler.HasFlag(args, "-s"))
                indexOfSource = ArgumentsHandler.GetIndexOfFlag(args, "-s");
            if (indexOfSource != 0)
                source = args[indexOfSource + 1];
            return source;
        }

        public static string GetFeature(string[] args)
        {
            string feature = string.Empty;
            int indexOfFeature = 0;
            if (ArgumentsHandler.HasFlag(args, "--feature"))
                indexOfFeature = ArgumentsHandler.GetIndexOfFlag(args, "--feature");
            else if (ArgumentsHandler.HasFlag(args, "-f"))
                indexOfFeature = ArgumentsHandler.GetIndexOfFlag(args, "-f");
            if (indexOfFeature != 0)
                feature = args[indexOfFeature + 1];
            return feature;
        }
    }
}
