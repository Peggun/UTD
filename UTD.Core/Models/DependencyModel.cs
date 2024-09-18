using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTD.Core.Models
{
    public class DependencyModel
    {
        public string Name { get; set; }
        public string Version { get; set; }

        public DependencyModel(string name, string version)
        {
            Name = name;
            Version = version;
        }
    }
}
