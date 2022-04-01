using CodeGenerator.Class;
using CodeGenerator.CSharp.Class;
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
            CreateTsApiClass(className, modelInfo);
            CreateCsControllerClass(className, modelInfo);

            //Test(className);
        }

        private static void CreateCsClass(string className, ClassModelMetaInfo modelInfo)
        {
            string outputFile = className + ".cs";
            CsClassClass template = new CsClassClass(modelInfo);
            string fileText = template.FileText;
            FileService.SaveFile(fileText, outputFile);
        }

        private static void CreateCsServiceClass(string className, ClassModelMetaInfo modelInfo)
        {
            string outputFile = className + "Service.cs";
            CsServiceClass template = new CsServiceClass(modelInfo);
            string fileText = template.FileText;
            FileService.SaveFile(fileText, outputFile);
        }

        private static void CreateTsApiClass(string className, ClassModelMetaInfo modelInfo)
        {
            string outputFile = className + "Service.tsx";
            TsApiClass cls = new TsApiClass(modelInfo);
            string fileText = cls.Render();
            FileService.SaveFile(fileText, outputFile);
        }

        private static void CreateCsControllerClass(string className, ClassModelMetaInfo modelInfo)
        {
            string outputFile = className + "Controller.cs";
            CsControllerClass cls = new CsControllerClass(modelInfo);
            string fileText = cls.Render();
            FileService.SaveFile(fileText, outputFile);
        }
        private static void CreateTsClass(string className, ClassModelMetaInfo modelInfo)
        {
            string outputFile = className + ".ts";
            TsClass template = new TsClass(modelInfo);
            string fileText = template.FileText;
            FileService.SaveFile(fileText, outputFile);
        }


        private static void Test(string className)
        {
            var testModelInfo = new ClassModelMetaInfo()
            {
                ModelName = "TestClass",
                PropsMetaInfo = new List<ClassPropMetaInfo> { new ClassPropMetaInfo() { Name = "Id", Type = "int" }, new ClassPropMetaInfo() { Name = "Name", Type = "string" } }
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
