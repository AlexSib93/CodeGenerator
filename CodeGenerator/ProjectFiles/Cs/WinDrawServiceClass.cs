using CodeGenerator.Enum;
using CodeGenerator.Interfaces;
using CodeGenerator.Metadata;
using System.Reflection.PortableExecutable;

namespace CodeGenerator.ProjectFiles.Cs
{
    public class WinDrawServiceClass : IClass, IGenerator
    {
        public string Name { get; set; }
        public string ParamName => StringHelper.ToLowerFirstChar(ClassInfo.Name);
        public string CodeScript { get; set; }
        public ProjectMetadata Project { get; set; }
        public WinDrawServiceClass(ModelMetadata classInfo, ProjectMetadata project)
        {
            ClassInfo = classInfo;
            Project = project;
            CodeScript = classInfo.InitData;
        }

        public ModelMetadata ClassInfo { get; set; }
        public string Gen()
        {
            return $"{Header}\n\n{Body}";
        }
        public string Header => $@"{UsingText}";

        public string UsingText => CodeScript.Substring(0,CodeScript.IndexOf("namespace"));

        public string Body => $@"namespace {Project.Namespace}
{{
    public class {ClassInfo.Name}
    {{

        public void RunService(dbconn _db, DataRow dr, Construction model)
        {{
            
        }}
    }}
}}
";
    }
}
