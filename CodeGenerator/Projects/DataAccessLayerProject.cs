using CodeGenerator.Classes;
using CodeGenerator.ProjectFiles.Cs;
using CodeGenerator.Interfaces;
using CodeGenerator.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Projects
{
    public class DataAccessLayerProject : Project, IProject
    {
        public DataAccessLayerProject(ProjectMetadata projectMetadata) : base(projectMetadata)
        {
            Name = "DataAccessLayer";
            string projectPath = $@"{projectMetadata.Path}\{Name}";
            foreach (ModelMetadata model in projectMetadata.Models)
            {
                Items.Add(new ProjectItem(this, new CsClass(model), model.Name, $"{projectPath}\\Models", "cs"));
            }

            //Auth
            ModelMetadata authModel = new ModelMetadata() { 
                Name = "User", 
                Props = new List<PropMetadata> {
                    new PropMetadata() { Name = "Id", Type = "int" },
                    new PropMetadata() { Name = "Login", Type = "string" },
                    new PropMetadata() { Name = "Barcode", Type = "string" },
                    new PropMetadata() { Name = "Password", Type = "string" },
                    new PropMetadata() { Name = "Name", Type = "string" }
                }
            };
            Items.Add(new ProjectItem(this, new CsClass(authModel), authModel.Name, $"{projectPath}\\Models", "cs"));

            Items.Add(new ProjectItem(this, new CsInterfaceUnitOfWork(projectMetadata.Models), "IUnitOfWork", projectPath, "cs"));
            Items.Add(new ProjectItem(this, new CsMockClass(projectMetadata.Models), "MockUnit", $"{projectPath}\\Data", "cs"));
        }

    }
}
