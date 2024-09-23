using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTD.Shared
{
    public class FilePaths
    {
        public static string appDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "UTD");
        public static string userDataFile = Path.Combine(appDataFolder, "data\\data.json");
    }
}
