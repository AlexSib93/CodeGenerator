using CodeGenerator.Interfaces;
using CodeGenerator.Metadata;
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
            Name = "WdScript";
        }

    }
}
