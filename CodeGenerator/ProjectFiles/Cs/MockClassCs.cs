using CodeGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.ProjectFiles.Cs
{
    public class MockClassCs : IClass, IGenerator
    {
        public string Name { get; set; }
        public MockClassCs(List<ModelMetadata> models)
        {
            Models = models;
        }

        public ModelMetadata ClassInfo { get; set; }
        public List<ModelMetadata> Models { get; set; }

        public string Header => $@"{UsingText}";
        public string Body => $@"namespace DataAccessLayer.Data
{{
    public class MockUnit : IUnitOfWork, IDisposable
    {{
{GetModelsText(Models)}

        public void Dispose()
        {{
        }}
    }}
}}
";

        public string UsingText => $@"using System;
using DataAccessLayer.Dto;";

        public string GetModelText(ModelMetadata classInfo)
        {
            string res = "";
            res += $@"
        private IRepository<{classInfo.Name}> _rep{classInfo.Name};
        public IRepository<{classInfo.Name}> Rep{classInfo.Name}
        {{
            get {{ return _rep{classInfo.Name} ?? (_rep{classInfo.Name} = new MockRepository<{classInfo.Name}>()); }}
        }}";

            return res;
        }

        public string GetModelsText(List<ModelMetadata> classesInfo)
        {
            string res = "";
            foreach (ModelMetadata classInfo in classesInfo)
            {
                res += $"{GetModelText(classInfo)}\n";

            }

            //Auth
            res += $"{GetModelText(new ModelMetadata() { Name = "User"})}\n";

            return res;
        }

        public string Gen()
        {
            return $"{Header}\n\n{Body}";
        }

    }
}
