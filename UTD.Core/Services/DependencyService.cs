using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json.Linq;
using UTD.Core.Interfaces;
using UTD.Core.Models;
using UTD.Shared;

namespace UTD.Core.Services
{
    public class DependencyService : IDependencyService
    {
        public List<DependencyModel> GetDependencies(string? project = "")
        {
            List<DependencyModel> dependencies = new List<DependencyModel>();

            // Construct project directory
            string baseDirectory = FilePathSelected.filePathSelected;
            string projectDir = string.IsNullOrEmpty(project)
                ? baseDirectory
                : Path.Combine(baseDirectory, project);

            try
            {
                // Search for all files in the project directory
                string[] files = Directory.GetFiles(projectDir, "*", SearchOption.AllDirectories);

                foreach (string file in files)
                {
                    if (file.EndsWith("project.assets.json"))
                    {
                        // Read and parse the project.assets.json file
                        string jsonContent = File.ReadAllText(file);
                        JObject assetsJson = JObject.Parse(jsonContent);

                        var libraries = assetsJson["libraries"] as JObject;
                        if (libraries != null)
                        {
                            foreach (var library in libraries)
                            {
                                // Key format is 'LibraryName/Version'
                                string key = library.Key;
                                var parts = key.Split('/');

                                if (parts.Length == 2)
                                {
                                    string name = parts[0];
                                    string version = parts[1];

                                    DependencyModel dependencyModel = new DependencyModel(name, version);
                                    dependencies.Add(dependencyModel);

                                    // Optionally log or print
                                    Console.WriteLine($"{dependencyModel.Name} {dependencyModel.Version}");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while retrieving dependencies: {ex.Message}");
            }

            return dependencies;
        }

        public void UpdateDependency(string name)
        {
            string projectDir = FilePathSelected.filePathSelected;
            try
            {
                // Create and configure the process to run the command
                Process process = new Process();
                ProcessStartInfo processStartInfo = new ProcessStartInfo
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    Arguments = $"/C cd \"{projectDir}\" && dotnet add package {name}",
                    RedirectStandardOutput = true,   // Capture the output
                    RedirectStandardError = true,
                    UseShellExecute = false,         // Required for redirection
                    CreateNoWindow = true
                };

                process.StartInfo = processStartInfo;

                // Start the process and wait for it to finish
                process.Start();
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                if (!string.IsNullOrEmpty(output))
                {
                    Console.WriteLine($"Output: {output}");
                }
                if (!string.IsNullOrEmpty(error))
                {
                    Console.WriteLine($"Error: {error}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while updating dependency: {ex.Message}");
            }
        }
    }
}