using CodeGenerator.Metadata;
using CodeGenerator;
using CodeGenerator.Services;
using CodeGenerator.Projects;
using System.Diagnostics;
using System.Net.NetworkInformation;
using LoadProjectMetadataFromWd;

namespace Tests
{
    [TestClass]
    public class GenWdScriptsTests
    {

        [TestMethod]
        public void TestLoadExceptedScripts()
        {
            List<ProjectMetadata> projects = LoadScriptService.GetExceptedScripts(new int[] { });

            Generator generator = new Generator();
            generator.Settings.GenBllProject = false;
            generator.Settings.GenDalProject = false;
            generator.Settings.GenTestsProject = false;
            generator.Settings.GenWebApiProject = false;
            generator.Settings.GenReactProject = false;
            generator.Settings.GenSqlCommandProject = false;
            generator.Settings.GenSolution = false;

            foreach (ProjectMetadata project in projects)
            {

                generator.GenCode(project);
            }
        }

        [TestMethod]
        public void TestLoadScripts()
        {
            List<ProjectMetadata> projects = LoadScriptService.GetScripts(new int[] { 63 });

            Generator generator = new Generator();
            generator.Settings.GenBllProject = false;
            generator.Settings.GenDalProject = false;
            generator.Settings.GenTestsProject = false;
            generator.Settings.GenWebApiProject = false;
            generator.Settings.GenReactProject = false;
            generator.Settings.GenSqlCommandProject = false;
            generator.Settings.GenSolution = false;

            foreach (ProjectMetadata project in projects)
            {

                generator.GenCode(project);
            }
        }

        [TestMethod]
        public void TestLoadEvents()
        {
            List<ProjectMetadata> projects = LoadScriptService.GetEvents(new int[] { 599 });

            Generator generator = new Generator();
            generator.Settings.GenBllProject = false;
            generator.Settings.GenDalProject = false;
            generator.Settings.GenTestsProject = false;
            generator.Settings.GenWebApiProject = false;
            generator.Settings.GenReactProject = false;
            generator.Settings.GenSqlCommandProject = false;
            generator.Settings.GenSolution = false;

            foreach (ProjectMetadata project in projects)
            {

                generator.GenCode(project);
            }
        }

        [TestMethod]
        public void TestLoadDesignerEvent()
        {
            List<ProjectMetadata> projects = LoadScriptService.GetDesignerEvent();

            Generator generator = new Generator();
            generator.Settings.GenBllProject = false;
            generator.Settings.GenDalProject = false;
            generator.Settings.GenTestsProject = false;
            generator.Settings.GenWebApiProject = false;
            generator.Settings.GenReactProject = false;
            generator.Settings.GenSqlCommandProject = false;
            generator.Settings.GenSolution = false;

            foreach (ProjectMetadata project in projects)
            {

                generator.GenCode(project);
            }
        }



    }
}