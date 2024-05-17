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
            generator.GenCode(ProjectMetadataHelper.TestProjectMetadata());
        }

        [TestMethod("GeneratorGui")]
        public void TestCreateGeneratorGui()
        {
            Settings.TemplatesPath = @"..\..\..\..\CodeGenerator\Templates";
            Generator generator = new Generator();
            generator.GenCode(ProjectMetadataHelper.GeneratorProjectMetadata());
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

    }
}