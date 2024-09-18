using System.Collections.Generic;

namespace UTD.Core.Models
{
    public class ProjectModel
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public SolutionModel Solution { get; set; }
        public List<DependencyModel> Dependencies { get; set; }

        public ProjectModel(string name, string path, SolutionModel solution, List<DependencyModel> dependencies)
        {
            Name = name;
            Path = path;
            Solution = solution;
            Dependencies = dependencies ?? new List<DependencyModel>();
        }
    }
}