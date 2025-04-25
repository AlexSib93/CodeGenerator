using CodeGenerator.ProjectFiles.Cs;
using CodeGenerator.Interfaces;
using CodeGenerator.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Projects
{
    public class WebApiProject : Project, IProject
    {
        public WebApiProject(ProjectMetadata projectMetadata) : base(projectMetadata)
        {
            Name = "WebApi";

            Items.Add(new ProjectItem(this, new WebApiProgrammCs(projectMetadata), "Program", $"{Metadata.Path}\\{Name}", "cs"));

            foreach (ModelMetadata classMeta in Metadata.Models)
            {
                Items.Add(new ProjectItem(this, new ControllerClassCs(classMeta), classMeta.Name, $"{Metadata.Path}\\{Name}\\Controllers", "cs"));
            }
            
        }

    }
}
