using System.Threading.Tasks;

namespace Quest
{
    class Program
    {   
        static async Task<int> Main(string[] args)
        {
            Setup.HandleConfiguration();
            return await ArgumentsHandler.Handle(args);            
        }
    }
}
