using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Interfaces
{
    public interface IProject
    {
        string Name { get; }
        string Description { get; }
        List<ProjectItem> Items { get; set; }
        void GenProjectFiles();
    }
}
