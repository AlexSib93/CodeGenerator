using CodeGenerator.Metadata;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Services
{ 
    public class ProjectFileManager
    {
        private string _projectDirectory;
        private string _projectFileExtension = ".gpr";

        public ProjectFileManager(string projectDirectory)
        {
            if (!Directory.Exists(projectDirectory))
            {
                Directory.CreateDirectory(projectDirectory);
            }
            _projectDirectory = projectDirectory;

        }

        public string[] GetProjectFiles()
        {
            string[] projectFiles = Directory.GetFiles(_projectDirectory, "*" + _projectFileExtension);

            return projectFiles;
        }

        public List<ProjectMetadata> GetProjects()
        {
            List<ProjectMetadata> projects = new List<ProjectMetadata>();
            string[] projectFiles = GetProjectFiles();
            foreach (string filePath in projectFiles)
            {
                projects.Add(LoadProjectByPath(filePath));
            }

            return projects;
        }

        public void CreateProjectFile(string projectName)
        {
            string projectFilePath = Path.Combine(_projectDirectory, projectName + _projectFileExtension);
            if (!File.Exists(projectFilePath))
            {
                File.Create(projectFilePath);
            }
        }

        public void SaveProject(string projectName, ProjectMetadata projMetadata)
        {
            string projectFilePath = Path.Combine(_projectDirectory, projectName + _projectFileExtension);
            if (!File.Exists(projectFilePath))
            {
                var file = File.Create(projectFilePath);
                file.Close();
            }
            string json = JsonConvert.SerializeObject(projMetadata);
            File.WriteAllText(projectFilePath, json);
        }

        public void DeleteProjectFile(string projectName)
        {
            string projectFilePath = Path.Combine(_projectDirectory, projectName + _projectFileExtension);
            if (File.Exists(projectFilePath))
            {
                File.Delete(projectFilePath);
            }
        }

        public ProjectMetadata LoadProject(string projectName)
        {
            string projectFilePath = Path.Combine(_projectDirectory, projectName + _projectFileExtension);
            ProjectMetadata projMetadata = LoadProjectByPath(projectFilePath);

            return projMetadata;
        }

        private static ProjectMetadata LoadProjectByPath(string projectFilePath)
        {
            ProjectMetadata projMetadata = null;
            if (File.Exists(projectFilePath))
            {
                using (StreamReader r = new StreamReader(projectFilePath))
                {
                    string json = r.ReadToEnd();
                    projMetadata = JsonConvert.DeserializeObject<ProjectMetadata>(json);
                }
            }

            return projMetadata;
        }
    }
}
