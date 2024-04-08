using CodeGenerator.Metadata;
using CodeGenerator.Projects;
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
        public static void GenCode(string projectName, string fileType)
        {
            ProjectMetadata projectMetadata = ReadMetaInfo(projectName);

            new ReactBootstrapProject(projectMetadata).GenProjectFiles();

            new WinDrawScriptProject(projectMetadata).GenProjectFiles();

            new BuisinessLogicLayerProject(projectMetadata).GenProjectFiles();

            new WebApiProject(projectMetadata).GenProjectFiles();
        }

        private static ProjectMetadata ReadMetaInfo(string projectName)
        {
            ProjectMetadata res = FileService.ReadFile<ProjectMetadata>($"{projectName}.json");

            return res;
        }
    }
}
