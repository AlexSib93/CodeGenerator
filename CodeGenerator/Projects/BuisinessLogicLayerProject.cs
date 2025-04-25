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
    public class BuisinessLogicLayerProject : Project, IProject
    {
        public BuisinessLogicLayerProject(ProjectMetadata projectMetadata) : base(projectMetadata)
        {
            Name = "BuisinessLogicLayer";
            string projectPath = $@"{projectMetadata.Path}\{Name}";
            foreach (ModelMetadata model in projectMetadata.Models)
            {
                Items.Add(new ProjectItem(this, new ServiceClassCs(model, projectMetadata), $"{model.Name}Service", $"{projectPath}\\Services", "cs"));
                Items.Add(new ProjectItem(this, new ServiceInterfaceClassCs(model), $"I{model.Name}Service", $"{projectPath}\\Services", "cs"));
            }
        }

    }
}
