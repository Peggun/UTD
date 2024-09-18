using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTD.Core.Interfaces
{
    public interface ISaveFileService
    {
        // All Data will be stored in AppData/Local/UTD


        void SaveFile<T>(string fileName, T data);
        T LoadData<T>(string fileName);
        List<string> GetAllSavedFiles();
        void DeleteSaveFile(string fileName);
    }
}
