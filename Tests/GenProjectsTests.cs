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
            Process hostApiProcess = BuildAndRunWebApi(ProjectMetadataHelper.GeneratorProjectMetadata());
            Process hostClientProcess = BuildAndRunClient(ProjectMetadataHelper.GeneratorProjectMetadata(), true);

            hostClientProcess.WaitForExit();
            hostApiProcess.WaitForExit();

            hostClientProcess.Kill();
            hostApiProcess.Kill();

        }

        [TestMethod("ComplectationArm")]
        public void TestCreateComplectationArm()
        {
            Settings.TemplatesPath = @"..\..\..\..\CodeGenerator\Templates";
            Generator generator = new Generator();
            generator.GenCode(ProjectMetadataHelper.ComplectationArmProjectMetadata());
        }

        [TestMethod]
        public void TestComplectationArm()
        {
            Process hostApiProcess = BuildAndRunWebApi(ProjectMetadataHelper.ComplectationArmProjectMetadata());
            Process hostClientProcess = BuildAndRunClient(ProjectMetadataHelper.ComplectationArmProjectMetadata(), true);

            hostClientProcess.WaitForExit();
            hostApiProcess.WaitForExit();

            hostClientProcess.Kill();
            hostApiProcess.Kill();

        }

        private Process BuildAndRunWebApi(ProjectMetadata project)
        {
            string webApiPath = $@"{project.Path}\WebApi\";
            bool useCmdWindow = true;
            Process process = RunCommand("dotnet", "run", webApiPath, useCmdWindow, false);

            return process;
        }

        private Process BuildAndRunClient(ProjectMetadata project, bool useCmdWindow = true)
        {
            string workDirrectory = $@"{project.Path}\ReactRedux";

            Process process = RunCommand("npm", "i", workDirrectory, useCmdWindow);
            process.Kill();
            process.Dispose();

            Process process2 = RunCommand("npm", "start", workDirrectory, useCmdWindow, false);

            return process2;
        }

        private static Process RunCommand(string fileName, string args, string workDirrectory, bool useCmdWindow, bool waitForExit = true)
        {
            Process process = new Process();

            process.StartInfo.FileName = fileName; // »спользуем команду dotnet
            process.StartInfo.Arguments = args; // »спользуем команду run дл€ запуска проекта .NET Core или .NET 5+
            process.StartInfo.WorkingDirectory = workDirrectory;
            process.StartInfo.UseShellExecute = useCmdWindow; // Ёто нужно, чтобы скрыть окно командной строки (если не требуетс€ отображение)
            process.StartInfo.RedirectStandardOutput = !useCmdWindow; // ”казываем, что хотим перехватить вывод командной строки
            process.StartInfo.CreateNoWindow = !useCmdWindow; // —крываем окно командной строки

            // «апускаем процесс
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