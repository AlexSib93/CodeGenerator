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
        public string Name { get; set; } = "react-terminal";

        public string Description { get; set; }
        public ProjectMetadata Metadata { get; set; }
        public List<ProjectItem> Items { get; set; } = new List<ProjectItem>();
        public ReactBootstrapProject(ProjectMetadata projectMetadata)
        {
            Metadata = projectMetadata;
        }

        public void GenProjectFiles()
        {
            foreach (ModelMetadata classMeta in Metadata.Classes)
            {
                Items.Add(new ProjectItem(this, new TsClass(classMeta), classMeta.Name, $"{Name}\\src\\models", "ts"));
                Items.Add(new ProjectItem(this, new TsApiClass(classMeta), $"{classMeta.Name}Service", $"{Name}\\src\\services", "ts"));
                Items.Add(new ProjectItem(this, new TsListFormClass(classMeta), $"{classMeta.Name}ListForm", $"{Name}\\src\\forms", "tsx"));
            }

            foreach (ProjectItem item in Items)
            {
                item.CreateProjectFile();
            }
        }
    }
}
