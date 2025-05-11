using CodeGenerator.Interfaces;
using CodeGenerator.Metadata;
using CodeGenerator.ProjectFiles.Cs;
using CodeGenerator.ProjectFiles.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CodeGenerator.Projects
{
    public class SqlScriptsProject : Project, IProject
    {
        public SqlScriptsProject(ProjectMetadata projectMetadata) : base(projectMetadata)
        {
            Name = "SqlCommand";
            string projectPath = $@"{projectMetadata.Path}\{Name}";
            Items.Add(new ProjectItem(this, new CreateDataBaseScript(projectMetadata), "Create Data Base", $"{projectPath}", "sql"));
        }

    }
}
