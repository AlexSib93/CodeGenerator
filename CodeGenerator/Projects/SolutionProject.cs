using CodeGenerator.Classes;
using CodeGenerator.CSharp.Class;
using CodeGenerator.Interfaces;
using CodeGenerator.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Projects
{
    public class SolutionProject : Project, IProject
    {
        public SolutionProject(ProjectMetadata projectMetadata) : base(projectMetadata)
        {
            Name = "Solution";
        }

        public void GenProjectFiles()
        {
            GenTemplateFiles();
            foreach (ModelMetadata classMeta in Metadata.Models)
            {
                Items.Add(new ProjectItem(this, new CsControllerClass(classMeta), classMeta.Name, $"{Metadata.Path}\\{Name}\\Controllers", "cs"));
            }

            foreach (ProjectItem item in Items)
            {
                item.CreateProjectFile();
            }
        }

        /// <summary>
        /// Копирование шалонных файлов проекта
        /// </summary>
        internal override void GenTemplateFiles()
        {
            string pathForCopyFiles = (!string.IsNullOrEmpty(Metadata.Path))
                ? Metadata.Path
                : Directory.GetCurrentDirectory();
            var templateGenerator = new TemplateFiles($@"{Settings.TemplatesPath}\{Name}", $@"{pathForCopyFiles}");
            templateGenerator.Gen();
        }

    }
}
