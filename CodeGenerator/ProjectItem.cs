using CodeGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public class ProjectItem : IGenerator
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public string Path { get; set; }
        public IProject Project { get; set; }
        public IGenerator Generator { get; set; }

        public ProjectItem(IProject project, IGenerator generator, string name, string path, string extension)
        {
            Project = project;
            Generator = generator;
            Name = name;
            Path = path;
            Extension = extension;
        }

        public string FileName => $"{Name}.{Extension}";

        public string Gen()
        {
            return Generator.Gen();
        }

        public void CreateProjectFile()
        {
            FileService.SaveFile(Gen(), FileName, Path);
        }
    }
}
