using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UTD.Core.Interfaces;
using UTD.Shared;

namespace UTD.Core.Services
{
    public class SaveFileService : ISaveFileService
    {
        private readonly string _appDataFolder;

        public SaveFileService()
        {
            // Set up the Local AppData path for your application
            _appDataFolder = FilePaths.appDataFolder;

            // Ensure the directory exists
            if (!Directory.Exists(_appDataFolder))
            {
                Directory.CreateDirectory(_appDataFolder);
            }
        }

        // Save any object (SolutionModel, ProjectModel, etc.) to JSON
        public void SaveFile<T>(string fileName, T data)
        {
            string filePath = Path.Combine(_appDataFolder, fileName);

            // Serialize the data to JSON and write it to the file
            string jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(filePath, jsonData);
        }

        // Load data back from JSON file
        public T LoadData<T>(string fileName)
        {
            string filePath = Path.Combine(_appDataFolder, fileName);

            if (File.Exists(filePath))
            {
                // Read the file and deserialize the JSON data
                string jsonData = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<T>(jsonData);
            }

            throw new FileNotFoundException("Save file not found.");
        }

        // List all saved files
        public List<string> GetAllSavedFiles()
        {
            List<string> saveFiles = new List<string>();

            if (Directory.Exists(_appDataFolder))
            {
                string[] files = Directory.GetFiles(_appDataFolder);
                foreach (string file in files)
                {
                    saveFiles.Add(Path.GetFileName(file));
                }
            }

            return saveFiles;
        }

        // Delete a specific saved file
        public void DeleteSaveFile(string fileName)
        {
            string filePath = Path.Combine(_appDataFolder, fileName);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            else
            {
                throw new FileNotFoundException("File to delete not found.");
            }
        }
    }
}
