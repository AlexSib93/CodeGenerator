using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Metadata
{
    public class TemplateFilesMetadata
    {
        public string Path { get; set; }
        public string OutputPath { get; set; }
        public TemplateFilesMetadata(string path, string outputPath)
        {
            Path = path;
            OutputPath = outputPath;
        }
    }
}
