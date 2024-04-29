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
    public class WebApiProject : Project, IProject
    {
        public string Name => "WebApi";
        public WebApiProject(ProjectMetadata projectMetadata) : base(projectMetadata)
        {

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

    }
}
