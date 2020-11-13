namespace Quest
{
    public static class DoHandler
    {
        public static bool Handle(string[] args)
        {            
            int indexOfSource = 0;
            if (ArgumentsHandler.HasFlag(args, "--source")) { 
                indexOfSource = ArgumentsHandler.GetIndexOfFlag(args, "--source");}
            else if (ArgumentsHandler.HasFlag(args, "-s"))
                indexOfSource = ArgumentsHandler.GetIndexOfFlag(args, "-s");
            if (indexOfSource != 0) { 
                string source = args[indexOfSource + 1];
                // USE THIS SOURCE variable to get path
            }
            int indexOfFeature = 0;
            if (ArgumentsHandler.HasFlag(args, "--feature"))
                indexOfFeature = ArgumentsHandler.GetIndexOfFlag(args, "--feature");
            else if (ArgumentsHandler.HasFlag(args, "-f"))
                indexOfFeature = ArgumentsHandler.GetIndexOfFlag(args, "-f");
            if (indexOfFeature != 0)
            {
                string feature = args[indexOfFeature + 1];
                // USE this feature variable to get feature path
            }           

            return false;
        }
    }
}
