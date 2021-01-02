using System.Threading.Tasks;

namespace Quest
{
    class Program
    {   
        static async Task<int> Main(string[] args)
        {
            // Check config file
            // Setup.HandleConfiguration();
            // Work with arguments
            return await ArgumentsHandler.Handle(args);            
        }
    }
}
