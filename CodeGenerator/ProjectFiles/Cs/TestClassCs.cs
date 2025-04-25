using CodeGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.ProjectFiles.Cs
{
    public class TestClassCs : IClass, IGenerator
    {
        public string Name { get; set; }
        public string ParamName => StringHelper.ToLowerFirstChar(ClassInfo.Name);
        public TestClassCs(ModelMetadata classInfo)
        {
            ClassInfo = classInfo;
        }

        public ModelMetadata ClassInfo { get; set; }

        public string Header => $@"{UsingText}";
        public string Body => $@"namespace Tests
{{

    [TestClass]
    public class {ClassInfo.Name}Test
    {{
{CreateSetAndGetPositionsOperationText()}
    }}
}}
";

        private string CreateSetAndGetPositionsOperationText()
        {
            string res = $@"        [TestMethod(""Создать и Получить все позиции"")]
        public void SetAndGetPositions()
        {{
            var service = new {ClassInfo.Name}Service(new MockUnit());
            service.Add(new {ClassInfo.Name}());
            service.Add(new {ClassInfo.Name}());
            IEnumerable<{ClassInfo.Name}> l = service.Get();
            Assert.IsTrue(l.Any());
        }}";

            return res;
        }

        public string Gen()
        {
            return $"{Header}\n\n{Body}";
        }

        public string UsingText => $@"using BuisinessLogicLayer.Services;
using DataAccessLayer.Data;
using DataAccessLayer.Dto;";

    }
}
