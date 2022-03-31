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
            ClassModelMetaInfo modelInfo = ReadMetaInfo(className);

            CreateCsClass(className, modelInfo);
            CreateTsClass(className, modelInfo);
            CreateCsServiceClass(className, modelInfo);

            //Test(className);
        }

        private static void CreateCsClass(string className, ClassModelMetaInfo modelInfo)
        {
            string outputFile = className + ".cs";
            CsClassTemplate template = new CsClassTemplate(modelInfo);
            string fileText = template.FileText;
            FileService.SaveFile(fileText, outputFile);
        }

        private static void CreateCsServiceClass(string className, ClassModelMetaInfo modelInfo)
        {
            string outputFile = className + "Service.cs";
            CsServiceTemplate template = new CsServiceTemplate(modelInfo);
            string fileText = template.FileText;
            FileService.SaveFile(fileText, outputFile);
        }

        private static void CreateTsClass(string className, ClassModelMetaInfo modelInfo)
        {
            string outputFile = className + ".ts";
            TsClassTemplate template = new TsClassTemplate(modelInfo);
            string fileText = template.FileText;
            FileService.SaveFile(fileText, outputFile);
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
