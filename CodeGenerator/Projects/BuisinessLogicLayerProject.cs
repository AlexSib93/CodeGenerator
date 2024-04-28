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
    public class BuisinessLogicLayerProject : IProject
    {
        public string Name { get; set; } = "BuisinessLagicLayer";
        public string Description { get; set; }
        public ProjectMetadata Metadata { get; set; }
        public List<ProjectItem> Items { get; set; } = new List<ProjectItem>();
        public string TemplateFolderPath { get; private set; } = @"Templates\BuisinessLogicLayer";
        public BuisinessLogicLayerProject(ProjectMetadata projectMetadata)
        {
            Metadata = projectMetadata;
        }

        public void GenProjectFiles()
        {
            GenTemplateFiles();
            foreach (ModelMetadata classMeta in Metadata.Models)
            {
                Items.Add(new ProjectItem(this, new CsClass(classMeta), classMeta.Name, $"{Metadata.Path}\\{Name}\\Views", "cs"));
                Items.Add(new ProjectItem(this, new CsServiceClass(classMeta), $"{classMeta.Name}Service", $"{Metadata.Path}\\{Name}\\Services", "cs"));
                Items.Add(new ProjectItem(this, new CsServiceInterfaceClass(classMeta), $"I{classMeta.Name}Service", $"{Metadata.Path}\\{Name}\\Services", "cs"));
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
