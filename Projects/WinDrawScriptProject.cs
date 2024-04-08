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
    public class WinDrawScriptProject : IProject
    {
        public string Name { get; set; } = "WinDrawScript";
        public string Description { get; set; }
        public ProjectMetadata Metadata { get; set; }
        public List<ProjectItem> Items { get; set; } = new List<ProjectItem>();
        public string TemplateFolderPath { get; private set; } = "Templates";

        public WinDrawScriptProject(ProjectMetadata projectMetadata)
        {
            Metadata = projectMetadata;
        }

        public void GenProjectFiles()
        {
            GenTemplateFiles();

            foreach (ModelMetadata classMeta in Metadata.Models)
            {
                Items.Add(new ProjectItem(this, new TsClass(classMeta), classMeta.Name, $"{Metadata.Path}\\{Name}\\src\\models", "ts"));
                Items.Add(new ProjectItem(this, new TsApiClass(classMeta), $"{classMeta.Name}Service", $"{Metadata.Path}\\{Name}\\src\\services", "ts"));
                Items.Add(new ProjectItem(this, new TsListFormClass(classMeta), $"{classMeta.Name}ListForm", $"{Metadata.Path}\\{Name}\\src\\forms", "tsx"));
            }


            foreach (ProjectItem item in Items)
            {
                item.CreateProjectFile();
            }
        }

        private void GenTemplateFiles()
        {
            string pathForCopyFiles = (!string.IsNullOrEmpty(Metadata.Path))
                ? Metadata.Path
                : Directory.GetCurrentDirectory();
            var templateGenerator = new TemplateFiles(TemplateFolderPath, $"{pathForCopyFiles}\\{Name}");
            templateGenerator.Gen();
        }

    }
}
