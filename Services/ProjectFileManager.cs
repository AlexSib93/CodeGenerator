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
            _projectDirectory = projectDirectory;
        }

        public string[] GetProjectFiles()
        {
            string[] projectFiles = Directory.GetFiles(_projectDirectory, "*" + _projectFileExtension);
            return projectFiles;
        }

        public void CreateProjectFile(string projectName)
        {
            string projectFilePath = Path.Combine(_projectDirectory, projectName + _projectFileExtension);
            if (!File.Exists(projectFilePath))
            {
                File.Create(projectFilePath);
            }
        }

        public void DeleteProjectFile(string projectName)
        {
            string projectFilePath = Path.Combine(_projectDirectory, projectName + _projectFileExtension);
            if (File.Exists(projectFilePath))
            {
                File.Delete(projectFilePath);
            }
        }
    }
}
