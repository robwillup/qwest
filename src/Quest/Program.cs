using System.Threading.Tasks;

namespace Quest
{
    class Program
    {   
        static async Task<int> Main(string[] args)
        {            
            Setup.HandleConfiguration(args);
            return await ArgumentsHandler.Handle(args);            
        }
    }
}
