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
    public class DataAccessLayerProject : Project, IProject
    {
        public DataAccessLayerProject(ProjectMetadata projectMetadata) : base(projectMetadata)
        {
            Name = "DataAccessLayer";
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

    }
}
