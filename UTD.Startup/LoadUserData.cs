using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using UTD.Core.Models;
using UTD.Shared;

namespace UTD.Startup
{
    public static class LoadUserData
    {
        public static void Load()
        {
            string jsonData = File.ReadAllText(FilePaths.userDataFile);
            SolutionModel solutionModel = JsonConvert.DeserializeObject<SolutionModel>(jsonData);

            Debug.WriteLine(solutionModel.ToString());
        }
    }
}
