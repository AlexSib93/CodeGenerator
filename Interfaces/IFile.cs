using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public interface IFile
    {
        string Name { get; }
        string Extension { get; }
    }
}
