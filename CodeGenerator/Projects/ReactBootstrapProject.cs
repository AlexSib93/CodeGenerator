﻿using CodeGenerator.Classes;
using CodeGenerator.ProjectFiles.Ts;
using CodeGenerator.Interfaces;
using CodeGenerator.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Projects
{
    public class ReactBootstrapProject : Project, IProject
    {
        public ReactBootstrapProject(ProjectMetadata projectMetadata) : base(projectMetadata)
        {
            TemplateProjectName = "ReactRedux";
            //Костыль пока папки проектов с таким же именем как в шаблоне
            Name = TemplateProjectName;
            foreach (ModelMetadata classMeta in Metadata.Models)
            {
                Items.Add(new ProjectItem(this, new TsClass(classMeta), classMeta.Name, $"{Metadata.Path}\\{Name}\\src\\models", "ts"));
                Items.Add(new ProjectItem(this, new TsApiClass(classMeta), $"{classMeta.Name}Service", $"{Metadata.Path}\\{Name}\\src\\services", "ts"));
            }
                        
            foreach (EnumMetadata enumMeta in Metadata.EnumTypes)
            {
                Items.Add(new ProjectItem(this, new TsEnum(enumMeta), enumMeta.Name, $"{Metadata.Path}\\{Name}\\src\\enums", "ts"));
            }

            foreach (FormMetadata formMeta in Metadata.Forms)
            {
                if(formMeta.EditForm != null)
                {
                    Items.Add(new ProjectItem(this, new TsEditForm(formMeta.EditForm, projectMetadata), $"{formMeta.EditForm.Name}", $"{Metadata.Path}\\{Name}\\src\\forms", "tsx"));
                }
                Items.Add(new ProjectItem(this, new TsListFormClass(formMeta, formMeta.EditForm), $"{formMeta.Name}", $"{Metadata.Path}\\{Name}\\src\\forms", "tsx"));
                
            }

            Items.Add(new ProjectItem(this, new TsAppClass(Metadata.Forms), $"App", $"{Metadata.Path}\\{Name}\\src", "tsx"));
            Items.Add(new ProjectItem(this, new TsNavBarClass(Metadata), $"Navbar", $"{Metadata.Path}\\{Name}\\src\\components", "tsx"));
        }

    }
}
