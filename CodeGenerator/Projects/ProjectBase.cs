using CodeGenerator.Classes;
using CodeGenerator.Interfaces;
using CodeGenerator.Metadata;

namespace CodeGenerator.Projects
{
    public class ProjectBase : IProject
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ProjectMetadata Metadata { get; set; }
        public List<ProjectItem> Items { get; set; }

        public void GenProjectFiles()
        {
            throw new NotImplementedException();
        }

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