using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTD.Core.Models
{
    public class SolutionModel
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public List<ProjectModel> projects { get; set; }

        public SolutionModel(string name, string path, List<ProjectModel> projectModels)
        {
            Name = name;
            Path = path;
            projects = projectModels ?? new List<ProjectModel>();
        }
    }
}
