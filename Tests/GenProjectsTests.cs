using CodeGenerator.Metadata;
using CodeGenerator;
using CodeGenerator.Services;
using CodeGenerator.Projects;

namespace Tests
{
    [TestClass]
    public class GenProjectsTests
    {
        [TestMethod]
        public void TestCreateProj()
        {
            Settings.TemplatesPath =  @"..\..\..\..\CodeGenerator\Templates";
            Generator generator = new Generator();
            generator.GenCode(TestProjectMetadata());
        }

        [TestMethod]
        public void TestCreateGeneratorGui()
        {
            Settings.TemplatesPath =  @"..\..\..\..\CodeGenerator\Templates";
            Generator generator = new Generator();
            generator.GenCode(GeneratorProjectMetadata());
        }

        private static ProjectMetadata TestProjectMetadata()
        {
            ProjectMetadata metadata = new ProjectMetadata();
            metadata.Name = "TestSoloution";
            metadata.Description = "Solution for testing generator when development";
            metadata.Path = "./TestSolution";
            ModelMetadata modelMetadata1 = new ModelMetadata()
            {
                Name = "TestModel1",
                Caption = "Тестовая модель 1",
                NameSpace = "TestNamespace",
                Props = new List<PropMetadata>()
                    {
                        new PropMetadata()
                        {
                            Name = "Name",
                            Type = "string"
                        },
                        new PropMetadata()
                        {
                            Name =  "Description",
                            Type = "string"
                        },
                        new PropMetadata()
                        {
                            Name =  "Id",
                            Type = "int"
                        }
                    }

            };
            ModelMetadata modelMetadata2 = new ModelMetadata()
            {
                Name = "DebugUnit",
                Caption = "Едиица отладки",
                NameSpace = "TestNamespace",
                Props = new List<PropMetadata>()
                    {
                        new PropMetadata()
                        {
                            Name = "Name",
                            Type = "string"
                        },
                        new PropMetadata()
                        {
                            Name =  "Id",
                            Type = "int"
                        },
                        new PropMetadata()
                        {
                            Name =  "Count",
                            Type = "int?"
                        },
                        new PropMetadata()
                        {
                            Name =  "Date",
                            Type = "DateTime"
                        }
                    }

            };
            metadata.Models = new List<ModelMetadata> {
                modelMetadata1,
                modelMetadata2
            };
            metadata.Forms = new List<FormMetadata>
            {
                new FormMetadata()
                {
                    Name = "TestModelList",
                    Caption = "Тестовые модели",
                    Model = modelMetadata1,
                    AddToNavBar = true
                }
            };

            return metadata;
        }

        
        private static ProjectMetadata GeneratorProjectMetadata()
        {
            string nameSpace = "CodeGeneratorGUI";
            ProjectMetadata metadata = new ProjectMetadata();
            metadata.Name = "CodeGeneratorGUI";
            metadata.Description = "GUI for manage projects to gen";
            metadata.Path = @"..\..\..\..\CodeGeneratorGUI";
            ModelMetadata modelMetadata1 = new ModelMetadata()
            {
                Name = "ModelMetadata",
                Caption = "Модель",
                NameSpace = nameSpace,
                Props = new List<PropMetadata>() {
                    new PropMetadata() { Name = "Name", Type = "string" },
                    new PropMetadata() { Name = "NameSpace", Type = "string" },
                    new PropMetadata() { Name = "Caption", Type = "string" }
                    //public List<PropMetadata> Props
                }
            };
            ModelMetadata modelMetadata2 = new ModelMetadata()
            {
                Name = "ProjectMetadata",
                Caption = "Проект",
                NameSpace = nameSpace,
                Props = new List<PropMetadata>() {
                    new PropMetadata() { Name = "Name", Type = "string" },
                    new PropMetadata() { Name =  "Description", Type = "string" },
                    new PropMetadata() { Name =  "Path", Type = "string"}
                    //    public List<ModelMetadata> Models { get; set; } = new List<ModelMetadata>();
                    //    public List<FormMetadata> Forms { get; set; } = new List<FormMetadata>();
                }
            };            
            ModelMetadata modelMetadata3 = new ModelMetadata()
            {
                Name = "FormMetadata",
                Caption = "Форма",
                NameSpace = nameSpace,
                Props = new List<PropMetadata>() {
                    new PropMetadata() { Name = "Name", Type = "string" },
                    new PropMetadata() { Name =  "Caption", Type = "string"},
                    new PropMetadata() { Name =  "Description", Type = "string" },
                    new PropMetadata() { Name =  "AddToNavBar", Type = "bool"}
                    //    public IEnumerable<ComponentMetadata> Components { get; set; }
                }
            };
            metadata.Models = new List<ModelMetadata> {
                modelMetadata1,
                modelMetadata2,
                modelMetadata3
            };
            metadata.Forms = new List<FormMetadata>
            {
                new FormMetadata()
                {
                    Name = "Projects",
                    Caption = "Проекты",
                    Model = modelMetadata2,
                    AddToNavBar = true
                },
                new FormMetadata()
                {
                    Name = "Models",
                    Caption = "Модели",
                    Model = modelMetadata1,
                    AddToNavBar = true
                },
                new FormMetadata()
                {
                    Name = "Forms",
                    Caption = "Формы",
                    Model = modelMetadata3,
                    AddToNavBar = true
                }
            };

            return metadata;
        }


    }
}