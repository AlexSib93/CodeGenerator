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
        public string Name { get; set; } = "BuisinessLagiLayer";
        public string Description { get; set; }
        public ProjectMetadata Metadata { get; set; }
        public List<ProjectItem> Items { get; set; } = new List<ProjectItem>();
        public BuisinessLogicLayerProject(ProjectMetadata projectMetadata)
        {
            Metadata = projectMetadata;
        }

        public void GenProjectFiles()
        {
            foreach (ModelMetadata classMeta in Metadata.Classes)
            {
                Items.Add(new ProjectItem(this, new CsClass(classMeta), classMeta.Name, $"{Name}\\Views", "cs"));
                Items.Add(new ProjectItem(this, new CsServiceClass(classMeta), $"{classMeta.Name}Service", $"{Name}\\Services", "cs"));
                Items.Add(new ProjectItem(this, new CsServiceInterfaceClass(classMeta), $"I{classMeta.Name}Service", $"{Name}\\Services", "cs"));
            }

            foreach (ProjectItem item in Items)
            {
                item.CreateProjectFile();
            }
        }
    }
}
