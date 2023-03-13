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
    public class WebApiProject : IProject
    {
        public string Name { get; set; } = "TerminalApi";

        public string Description { get; set; }
        public ProjectMetadata Metadata { get; set; }
        public List<ProjectItem> Items { get; set; } = new List<ProjectItem>();
        public WebApiProject(ProjectMetadata projectMetadata)
        {
            Metadata = projectMetadata;
        }

        public void GenProjectFiles()
        {
            foreach (ModelMetadata classMeta in Metadata.Classes)
            {
                Items.Add(new ProjectItem(this, new CsControllerClass(classMeta), classMeta.Name, $"{Name}\\Controllers", "cs"));
            }

            foreach (ProjectItem item in Items)
            {
                item.CreateProjectFile();
            }
        }
    }
}
