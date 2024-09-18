using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTD.Core.Models;

namespace UTD.Core.Interfaces
{
    public interface IDependencyService
    {
        List<DependencyModel> GetDependencies(string? project = "");
        void UpdateDependency(string name);
    }
}
