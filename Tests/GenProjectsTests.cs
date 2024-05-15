using CodeGenerator.Metadata;
using CodeGenerator;
using CodeGenerator.Services;
using CodeGenerator.Projects;
using System.Diagnostics;
using System.Net.NetworkInformation;

namespace Tests
{
    [TestClass]
    public class GenProjectsTests
    {
        [TestMethod]
        public void TestCreateProj()
        {
            Settings.TemplatesPath = @"..\..\..\..\CodeGenerator\Templates";
            Generator generator = new Generator();
            generator.GenCode(TestProjectMetadata());
        }

        [TestMethod]
        public void TestCreateGeneratorGui()
        {
            Settings.TemplatesPath = @"..\..\..\..\CodeGenerator\Templates";
            Generator generator = new Generator();
            generator.GenCode(GeneratorProjectMetadata());
        }

        [TestMethod]
        public void TestGui()
        {
            Process hostApiProcess = BuildAndRunWebApi();
            Process hostClientProcess = BuildAndRunClient(true);

            hostClientProcess.WaitForExit();
            hostApiProcess.WaitForExit();

            hostClientProcess.Kill();
            hostApiProcess.Kill();

        }

        [TestMethod]
        public void TestClientApp()
        {
            Process hostClientProcess = BuildAndRunClient(true);
            hostClientProcess.WaitForExit();
            hostClientProcess.Kill();
        }

        private Process BuildAndRunWebApi()
        {
            string webApiPath = @"..\..\..\..\CodeGeneratorGUI\WebApi\";
            bool useCmdWindow = true;
            Process process = RunCommand("dotnet", "run", webApiPath, useCmdWindow, false);

            return process;
        }

        private Process BuildAndRunClient(bool useCmdWindow = true)
        {
            string workDirrectory = @"..\..\..\..\CodeGeneratorGUI\ReactRedux";

            Process process = RunCommand("npm", "i", workDirrectory, useCmdWindow);
            process.Kill();
            process.Dispose();

            Process process2 = RunCommand("npm", "start", workDirrectory, useCmdWindow, false);

            return process2;
        }

        private static Process RunCommand(string fileName, string args, string workDirrectory, bool useCmdWindow, bool waitForExit = true)
        {
            Process process = new Process();

            process.StartInfo.FileName = fileName; // ���������� ������� dotnet
            process.StartInfo.Arguments = args; // ���������� ������� run ��� ������� ������� .NET Core ��� .NET 5+
            process.StartInfo.WorkingDirectory = workDirrectory;
            process.StartInfo.UseShellExecute = useCmdWindow; // ��� �����, ����� ������ ���� ��������� ������ (���� �� ��������� �����������)
            process.StartInfo.RedirectStandardOutput = !useCmdWindow; // ���������, ��� ����� ����������� ����� ��������� ������
            process.StartInfo.CreateNoWindow = !useCmdWindow; // �������� ���� ��������� ������

            // ��������� �������
            process.Start();

            if (!useCmdWindow)
            {
                string output = process.StandardOutput.ReadToEnd();
                Console.WriteLine(output);
            }

            if (waitForExit)
            {
                process.WaitForExit();
            }

            return process;
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
                Caption = "�������� ������ 1",
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
                Caption = "������ �������",
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
                    Caption = "�������� ������",
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
                Caption = "������",
                NameSpace = nameSpace,
                Props = new List<PropMetadata>() {
                    new PropMetadata() { Name = "Name", Caption = "���", Type = "string" },
                    new PropMetadata() { Name = "NameSpace", Caption = "������������ ����", Type = "string" },
                    new PropMetadata() { Name = "Caption", Caption = "������������ ���", Type = "string" },
                    new PropMetadata { Name = "Props", Caption = "��������", Type = "List<PropMetadata>" }
                }                
            };
            ModelMetadata modelMetadata2 = new ModelMetadata()
            {
                Name = "ProjectMetadata",
                Caption = "������",
                NameSpace = nameSpace,
                Props = new List<PropMetadata>() {
                    new PropMetadata() { Name = "Name", Caption = "������������", Type = "string" },
                    new PropMetadata() { Name = "Description", Caption = "��������", Type = "string" },
                    new PropMetadata() { Name = "Path", Caption = "����", Type = "string"},
                    new PropMetadata { Name = "Models", Caption = "������", Type = "List<ModelMetadata>" },
                    new PropMetadata { Name = "Forms", Caption = "�����", Type = "List<FormMetadata>" }
                }
            };
            ModelMetadata modelMetadata3 = new ModelMetadata()
            {
                Name = "FormMetadata",
                Caption = "�����",
                NameSpace = nameSpace,
                Props = new List<PropMetadata>() {
                    new PropMetadata() { Name = "Name", Caption = "������������", Type = "string" },
                    new PropMetadata() { Name =  "Caption", Caption = "������������ ���", Type = "string"},
                    new PropMetadata() { Name =  "Description", Caption = "��������", Type = "string" },
                    new PropMetadata() { Name =  "AddToNavBar", Caption = "�������� � ������ ���������", Type = "bool"}
                    //new PropMetadata { Name = "Components", Caption = "�����", Type = "List<ComponentMetadata>" }
                    //    public IEnumerable<ComponentMetadata> Components { get; set; }
                }
            };
            ModelMetadata modelMetadata4 = new ModelMetadata()
            {
                Name = "PropMetadata",
                Caption = "��������",
                NameSpace = nameSpace,
                Props = new List<PropMetadata>() {
                    new PropMetadata() { Name = "Name", Caption = "������������", Type = "string" },
                    new PropMetadata() { Name =  "Type", Caption="��� ������ C#", Type = "string"},
                    new PropMetadata() { Name =  "Caption", Caption="������������ ���", Type = "string" },
                }
            };
            metadata.Models = new List<ModelMetadata> {
                modelMetadata1,
                modelMetadata2,
                modelMetadata3,
                modelMetadata4
            };
            metadata.Forms = new List<FormMetadata>
            {
                new FormMetadata()
                {
                    Name = "Projects",
                    Caption = "�������",
                    Model = modelMetadata2,
                    AddToNavBar = true,
                    Components = new ComponentMetadata[] {
                        new ComponentMetadata() { Name = "Projects", Caption = "�������", Type = "Table", Props = modelMetadata2.Props  }
                    }

                },
                new FormMetadata()
                {
                    Name = "Models",
                    Caption = "������",
                    Model = modelMetadata1,
                    AddToNavBar = true,
                    Components = new ComponentMetadata[] {
                        new ComponentMetadata() { Name = "Models", Caption = "������", Type = "Table", Props = modelMetadata1.Props  },
                        new ComponentMetadata() { Type = "AddButton"  } 
                    },
                    EditForm = new FormMetadata()
                    {
                        Name = "Model",
                        Caption = "������",
                        Model = modelMetadata1,
                        Components = new ComponentMetadata[] {
                            new ComponentMetadata() { Name = "Name", Caption = "������������", Type = "Input"  },
                            new ComponentMetadata() { Name = "NameSpace", Caption = "������������ ����", Type = "Input"  },
                            new ComponentMetadata() { Name = "Caption", Caption = "������������ ���", Type = "Input"  },
                            new ComponentMetadata() { Name = "Props", Caption = "��������", Type = "Table", Props = modelMetadata4.Props },
                            new ComponentMetadata() { Type = "SubmitButton"  }
                        }
                    }
                },
                new FormMetadata()
                {
                    Name = "Forms",
                    Caption = "�����",
                    Model = modelMetadata3,
                    AddToNavBar = true,
                    Components = new ComponentMetadata[] {
                        new ComponentMetadata() { Name = "Forms", Caption = "�����", Type = "Table", Props = modelMetadata3.Props  }
                    }
                }
            };


            return metadata;
        }


    }
}