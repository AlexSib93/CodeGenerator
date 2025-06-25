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
        public string CodeClass { get; set; }
        public ProjectMetadata Project { get; set; }
        public WinDrawServiceClass(ModelMetadata classInfo, ProjectMetadata project)
        {
            ClassInfo = classInfo;
            Project = project;
            CodeScript = classInfo.InitData;
        }
        public WinDrawServiceClass(ModelMetadata classInfo, ProjectMetadata project, string code)
        {
            ClassInfo = classInfo;
            Project = project;
            CodeScript = classInfo.InitData;
            CodeClass = code;
        }

        public ModelMetadata ClassInfo { get; set; }
        public string Gen()
        {
            return $"{Header}\n\n{Body}";
        }
        public string Header => $@"{SharpCodeAnalizator.UsingText(CodeScript)}";

        public string Body => $@"namespace {Project.Namespace}
{{
{RunServiceCode()}
}}
";

        private object RunServiceCode()
        {
            string res = $@"    public class {ClassInfo.Name}
    {{
        public void RunService(dbconn _db, DataRow dr, Construction model)
        {{
            
        }}
    }}";

            if(!string.IsNullOrEmpty( CodeClass))
            {
                if(Name == "RunCalc")
                {
                    CodeClass = CodeClass
                        .Replace(" Run(", " RunService(")
                        .Replace("class RunCalc", "class " + ClassInfo.Name)
                        .Replace(" RunCalc(", " " + ClassInfo.Name + "(");
                }

                res = CodeClass;
            }

            return res;
        }
    }
}
