using CodeGenerator.Metadata;
using System.Diagnostics;

namespace CodeGenerator
{
    public static class ProjectRunner
    {
        public static void RunProject(ProjectMetadata proj)
        {
            Process hostApiProcess = BuildAndRunWebApi(proj);
            Process hostClientProcess = BuildAndRunClient(proj, true);

            hostClientProcess.WaitForExit();
            hostApiProcess.WaitForExit();

            hostClientProcess.Kill();
            hostApiProcess.Kill();
        }

        public static Process RunCommand(string fileName, string args, string workDirrectory, bool useCmdWindow, bool waitForExit = true)
        {
            Process process = new Process();

            process.StartInfo.FileName = fileName; // Используем команду dotnet
            process.StartInfo.Arguments = args; // Используем команду run для запуска проекта .NET Core или .NET 5+
            process.StartInfo.WorkingDirectory = workDirrectory;
            process.StartInfo.UseShellExecute = useCmdWindow; // Это нужно, чтобы скрыть окно командной строки (если не требуется отображение)
            process.StartInfo.RedirectStandardOutput = !useCmdWindow; // Указываем, что хотим перехватить вывод командной строки
            process.StartInfo.CreateNoWindow = !useCmdWindow; // Скрываем окно командной строки

            // Запускаем процесс
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


        public static Process BuildAndRunWebApi(ProjectMetadata project)
        {
            string webApiPath = $@"{project.Path}\WebApi\";
            bool useCmdWindow = true;
            Process process = ProjectRunner.RunCommand("dotnet", "run", webApiPath, useCmdWindow, false);

            return process;
        }

        public static Process BuildAndRunClient(ProjectMetadata project, bool useCmdWindow = true)
        {
            string workDirrectory = $@"{project.Path}\ReactRedux";

            Process process = ProjectRunner.RunCommand("npm", "i", workDirrectory, useCmdWindow);
            process.Kill();
            process.Dispose();

            Process process2 = ProjectRunner.RunCommand("npm", "start", workDirrectory, useCmdWindow, false);

            return process2;
        }
    }
}