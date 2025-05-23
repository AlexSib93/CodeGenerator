using CodeGenerator.Classes;
using CodeGenerator.Interfaces;
using CodeGenerator.Metadata;

namespace CodeGenerator.Projects
{
    public class Project : IProject
    {
        public string Name { get; set; }
        public string TemplateProjectName { get; set; }
        public string Description { get; set; }
        public ProjectMetadata Metadata { get; set; }
        public List<ProjectItem> Items { get; set; } = new List<ProjectItem>();

        public Project(ProjectMetadata projectMetadata)
        {
            Metadata = projectMetadata;
            Name = projectMetadata.Name;
        }

        public void GenProjectFiles()
        {
            GenTemplateFiles();
            foreach (ProjectItem item in Items)
            {
                item.CreateProjectFile();
            }
        }

        /// <summary>
        /// Копирование шалонных файлов проекта
        /// </summary>
        internal virtual void GenTemplateFiles()
        {
            string pathForCopyFiles = (!string.IsNullOrEmpty(Metadata.Path))
                ? Metadata.Path
                : Directory.GetCurrentDirectory();
            var templateGenerator = new TemplateFiles(Metadata, $@"{Settings.TemplatesPath}\{TemplateProjectName}", $@"{pathForCopyFiles}\{Name}");
            templateGenerator.Gen();
        }

    }
}