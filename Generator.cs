using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public static class Generator
    {
        public static void GenCode(string className, string fileType)
        {
            string outputFile = className + ".cs";
            ClassModelMetaInfo modelInfo = ReadMetaInfo(className);

            CsClassTemplate template = new CsClassTemplate(modelInfo);

            string fileText = template.FileText;

            FileService.SaveFile(fileText, outputFile);

            //Test(className);
        }

        private static void Test(string className)
        {
            var testModelInfo = new ClassModelMetaInfo()
            {
                ClassModelName = "TestClass",
                PropMetaInfo = new List<ClassPropMetaInfo> { new ClassPropMetaInfo() { Name = "Id", Type = "int" }, new ClassPropMetaInfo() { Name = "Name", Type = "string" } }
            };

            string jsonString = JsonSerializer.Serialize(testModelInfo);
            FileService.SaveFile(jsonString, className + ".json");
        }

        private static ClassModelMetaInfo ReadMetaInfo(string className)
        {
            ClassModelMetaInfo res = FileService.ReadFile<ClassModelMetaInfo>($"{className}.json");

            return res;
        }
    }
}
