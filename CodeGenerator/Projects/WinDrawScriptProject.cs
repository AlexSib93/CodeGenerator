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
    public class WinDrawScriptProject : Project, IProject
    {
        public string Name => "wd-script";

        public WinDrawScriptProject(ProjectMetadata projectMetadata): base(projectMetadata)
        {

        }

        public void GenProjectFiles()
        {
            GenTemplateFiles();

        }

    }
}
