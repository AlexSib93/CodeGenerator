using CodeGenerator.Classes;
using CodeGenerator.Interfaces;
using CodeGenerator.Metadata;

namespace CodeGenerator.Projects
{
    public class SolutionProject : Project, IProject
    {
        public SolutionProject(ProjectMetadata projectMetadata) : base(projectMetadata)
        {
            Name = "Solution";
        }

        /// <summary>
        /// Копирование шалонных файлов проекта
        /// </summary>
        internal override void GenTemplateFiles()
        {
            string pathForCopyFiles = (!string.IsNullOrEmpty(Metadata.Path))
                ? Metadata.Path
                : Directory.GetCurrentDirectory();
            var templateGenerator = new TemplateFiles(Metadata, $@"{Settings.TemplatesPath}\{Name}", $@"{pathForCopyFiles}");
            templateGenerator.Gen();
        }

    }
}
