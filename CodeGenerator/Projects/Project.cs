using CodeGenerator.Classes;
using CodeGenerator.Interfaces;
using CodeGenerator.Metadata;

namespace CodeGenerator.Projects
{
    public class Project : IProject
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ProjectMetadata Metadata { get; set; }
        public List<ProjectItem> Items { get; set; } = new List<ProjectItem>();

        public Project(ProjectMetadata projectMetadata)
        {
            Metadata = projectMetadata;
        }

        public void GenProjectFiles()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Копирование шалонных файлов проекта
        /// </summary>
        internal void GenTemplateFiles()
        {
            string pathForCopyFiles = (!string.IsNullOrEmpty(Metadata.Path))
                ? Metadata.Path
                : Directory.GetCurrentDirectory();
            var templateGenerator = new TemplateFiles($@"{Settings.TemplatesPath}\{Name}", $@"{pathForCopyFiles}\{Name}");
            templateGenerator.Gen();
        }
    }
}