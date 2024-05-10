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
    }
}