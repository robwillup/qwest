using System.Threading.Tasks;

namespace Quest
{
    class Program
    {   
        static async Task Main(string[] args)
        {
            // Check config file
            Setup.HandleConfiguration();
            // Work with arguments
            await ArgumentsHandler.Handle(args);            
        }
    }
}
