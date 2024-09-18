using System.IO;
using System.Collections.Generic;
using UTD.Core.Interfaces;
using UTD.Core.Models;

namespace UTD.Core.Services
{
    public class ProjectService : IProjectService
    {
        private readonly ISolutionService _solutionService;
        private readonly IDependencyService _dependencyService;

        public ProjectService(ISolutionService solutionService, IDependencyService dependencyService)
        {
            _solutionService = solutionService;
            _dependencyService = dependencyService;
        }

        public List<ProjectModel> GetProjects(string solutionDirectory)
        {
            // Retrieve the solution file
            SolutionModel solution = _solutionService.GetSolution(solutionDirectory);
            if (solution == null)
            {
                // If no solution file is found, return an empty list
                return new List<ProjectModel>();
            }

            // Retrieve all the project files (.csproj) within the solution directory
            string[] projectFiles = Directory.GetFiles(solutionDirectory, "*.csproj", SearchOption.AllDirectories);

            // Initialize a list to hold the project models
            List<ProjectModel> projects = new List<ProjectModel>();

            foreach (var projectFile in projectFiles)
            {
                // Get the project name from the file name
                string projectName = Path.GetFileNameWithoutExtension(projectFile);

                // Get dependencies for this project
                List<DependencyModel> dependencies = _dependencyService.GetDependencies(projectName);

                // Create a ProjectModel instance and add it to the list
                projects.Add(new ProjectModel(projectName, projectFile, solution, dependencies));
            }

            return projects;
        }
    }
}
