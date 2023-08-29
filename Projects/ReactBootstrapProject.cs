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
    public class ReactBootstrapProject : IProject
    {
        public string Name { get; set; } = "react-redux";
        public string Description { get; set; }
        public ProjectMetadata Metadata { get; set; }
        public List<ProjectItem> Items { get; set; } = new List<ProjectItem>();
        public string TemplateFolderPath { get; private set; } = "Templates";

        public ReactBootstrapProject(ProjectMetadata projectMetadata)
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
            var templateGenerator = new TemplateFiles(TemplateFolderPath, Metadata.Path);
            templateGenerator.Gen();
        }

    }
}
