using UTD.Core.Models;

namespace UTD.Core.Interfaces
{
    public interface ISolutionService
    {
        SolutionModel GetSolution(string solutionDirectory);
    }
}