﻿using CodeGenerator.Classes;
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
    public class TestsProject : Project, IProject
    {
        public TestsProject(ProjectMetadata projectMetadata) : base(projectMetadata)
        {
            TemplateProjectName = "Tests";
            //Костыль пока папки проектов с таким же именем как в шаблоне
            Name = TemplateProjectName;
            string projectPath = $@"{projectMetadata.Path}\{Name}";
            foreach (ModelMetadata model in projectMetadata.Models)
            {
                Items.Add(new ProjectItem(this, new TestClassCs(model), $"{model.Name}Test", projectPath, "cs"));
            }
        }

    }
}
