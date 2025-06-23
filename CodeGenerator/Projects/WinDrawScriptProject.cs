using CodeGenerator.Classes;
using CodeGenerator.Interfaces;
using CodeGenerator.Metadata;
using CodeGenerator.ProjectFiles.Cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Projects
{
    public class WinDrawScriptProject : Project, IProject
    {
        public WinDrawScriptProject(ProjectMetadata projectMetadata): base(projectMetadata)
        {
            TemplateProjectName = "WdScript";             
            
            foreach (ModelMetadata classMeta in Metadata.Models)
            {
                Items.Add(new ProjectItem(this, new WinDrawServiceClass(classMeta, projectMetadata), classMeta.Name, $"{Metadata.Path}\\{Name}", "cs"));
            }

        }

    }
}
