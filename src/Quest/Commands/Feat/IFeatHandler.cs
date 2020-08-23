using Quest.Models;

namespace Quest.Commands.Feat
{
    interface IFeatHandler
    {
        bool ValidateArgs(string[] args);
        Feature ParseArgs(string[] args);
    }
}
