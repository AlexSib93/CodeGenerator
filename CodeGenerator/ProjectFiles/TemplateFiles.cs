using CodeGenerator.Interfaces;
using CodeGenerator.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodeGenerator.Classes
{
    public class TemplateFiles : IGenerator
    {
        public ProjectMetadata ProjectMetadata { get; set; }
        public TemplateFilesMetadata TemplateFilesMetadata { get; set; }

        public TemplateFiles(ProjectMetadata projectMetadata, string templatePath, string outputPath)
        {
            TemplateFilesMetadata = new TemplateFilesMetadata(templatePath, outputPath);
            ProjectMetadata = projectMetadata;
        }

        public string Gen()
        {
            string text = "";
            try
            {
                CopyDirectory(TemplateFilesMetadata.Path, TemplateFilesMetadata.OutputPath, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }

            return text;
        }

        void CopyDirectory(string sourceDir, string destinationDir, bool recursive)
        {
            var dir = new DirectoryInfo(sourceDir);

            if (!dir.Exists)
                throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");

            DirectoryInfo[] dirs = dir.GetDirectories();

            DirectoryInfo destDir = Directory.CreateDirectory(destinationDir);

            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, ReplaceContent(file.Name, "TemplateProjectName", "ProjectName"));

                ReplaceInFile(file.FullName, targetFilePath);
            }

            if (recursive)
            {
                foreach (DirectoryInfo subDir in dirs)
                {
                    string newDestinationDir = Path.Combine(destinationDir, ReplaceContent(subDir.Name, "TemplateProjectName", "ProjectName"));
                    CopyDirectory(subDir.FullName, newDestinationDir, true);
                }
            }
        }
        public void ReplaceInFile(string filePathIn, string filePathOut)
        {

            StreamReader reader = new StreamReader(filePathIn);
            string content = reader.ReadToEnd();
            reader.Close();

            //ToDo: вынести в настройку 
            if(ProjectMetadata != null && !string.IsNullOrEmpty(ProjectMetadata.Name))
                content = ReplaceContent(content, "TemplateProjectName", ProjectMetadata.Name);

            if (ProjectMetadata != null && !string.IsNullOrEmpty(ProjectMetadata.DbConnectionString))
                content = ReplaceContent(content, "DefaultConnectionString", ProjectMetadata.DbConnectionString);


            content = ReplaceContent(content, "TemplateProjectNamespace", "ProjectNamespace");

            content = ReplaceContent(content, "TemplateProjectWebApiPort", ProjectMetadata.WebApiHttpsPort.ToString());
            content = ReplaceContent(content, "TemplateProjectDevServerPort", ProjectMetadata.DevServerPort.ToString());

            StreamWriter writer = new StreamWriter(filePathOut);
            writer.Write(content);
            writer.Close();
        }

        private static string ReplaceContent(string content, string searchText, string replaceText)
        {
            content = Regex.Replace(content, searchText, replaceText);
            return content;
        }
    }
}
