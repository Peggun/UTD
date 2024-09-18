using System.IO;
using UTD.Core.Interfaces;
using UTD.Core.Models;

namespace UTD.Core.Services
{
    public class SolutionService : ISolutionService
    {
        /// <summary>
        /// Usage: SolutionModel model = new SolutionModel(UTD.Shared.FilePathSelected.filePathSelected);
        /// </summary>
        /// <param name="solutionDirectory"></param>
        /// <returns></returns>
        public SolutionModel GetSolution(string solutionDirectory)
        {
            DependencyService service = new DependencyService();
            ProjectService projectService = new ProjectService(this, service);
            // Search for the solution file in the given directory
            string solutionFile = Directory
                .GetFiles(solutionDirectory, "*.sln", SearchOption.TopDirectoryOnly)
                .FirstOrDefault();  // Get the first solution file found

            List<ProjectModel> projects = projectService.GetProjects(solutionFile);

            if (string.IsNullOrEmpty(solutionFile))
            {
                // No solution file found, return null
                return null;
            }

            // Use Path methods to extract the solution name and path
            string solutionName = Path.GetFileNameWithoutExtension(solutionFile);

            return new SolutionModel(solutionName, solutionFile, projects);
        }
    }
}