using CodeGenerator.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Interfaces
{
    public interface IProject
    {
        ProjectMetadata Metadata { get; set; }
        List<ProjectItem> Items { get; set; }
        void GenProjectFiles();
    }
}
