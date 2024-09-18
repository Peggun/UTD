using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTD.Core.Models;
using UTD.Core.Services;

namespace UTD.Cli
{
    public class Program
    {
        public static void Main()
        {
            DependencyService dependencyService = new DependencyService();
            SolutionService solutionService = new SolutionService();

            SolutionModel model = solutionService.GetSolution("");

            Console.WriteLine(model.Name);
            Console.ReadLine();
        }
    }
}
