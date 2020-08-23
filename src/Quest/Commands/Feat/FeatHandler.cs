using Quest.Models;
using System;
using System.Linq;

namespace Quest.Commands.Feat
{
    public static class FeatHandler
    {
        public static Feature ParseArgs(string[] args)
        {
            throw new NotImplementedException();
        }

        public static bool ValidateArgs(string[] args)
        {
            if (string.IsNullOrEmpty(args[1]))
                return false;
            if (!args.Contains("--path"))
                return false;
            if (!args.Contains("--desc"))
                return false;
            throw new NotImplementedException();
        }
    }
}
