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
    public class TestsProject : Project, IProject
    {
        public TestsProject(ProjectMetadata projectMetadata) : base(projectMetadata)
        {
            Name = "Tests";
        }

    }
}
