using System.Collections.Generic;
using UTD.Core.Models;

namespace UTD.Core.Interfaces
{
    public interface IProjectService
    {
        List<ProjectModel> GetProjects(string solutionDirectory);
    }
}
