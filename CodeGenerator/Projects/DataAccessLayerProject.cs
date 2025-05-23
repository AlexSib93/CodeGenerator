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
            TemplateProjectName = "DataAccessLayer";
            //Костыль пока папки проектов с таким же именем как в шаблоне
            Name = TemplateProjectName;
            string projectPath = $@"{projectMetadata.Path}\{TemplateProjectName}";
            foreach (ModelMetadata model in projectMetadata.Models)
            {
                Items.Add(new ProjectItem(this, new ClassCs(model), model.Name, $"{projectPath}\\Models", "cs"));
            }
            
            foreach (EnumMetadata enumMetadata in projectMetadata.EnumTypes)
            {
                Items.Add(new ProjectItem(this, new EnumCs(enumMetadata), enumMetadata.Name, $"{projectPath}\\Enums", "cs"));
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
            Items.Add(new ProjectItem(this, new ClassCs(authModel), authModel.Name, $"{projectPath}\\Models", "cs"));
            Items.Add(new ProjectItem(this, new InterfaceUnitOfWorkCs(projectMetadata.Models), "IUnitOfWork", projectPath, "cs"));
            Items.Add(new ProjectItem(this, new MockClassCs(projectMetadata.Models), "MockUnit", $"{projectPath}\\Data", "cs"));
            Items.Add(new ProjectItem(this, new EfUnitClassCs(projectMetadata.Models), "EfUnit", $"{projectPath}\\Data", "cs"));
            Items.Add(new ProjectItem(this, new DataBaseContextClassCs(projectMetadata.Models), "DataBaseContext", $"{projectPath}\\Data", "cs"));
        }

    }
}
