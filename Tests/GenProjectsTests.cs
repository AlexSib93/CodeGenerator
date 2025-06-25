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
    public class GenProjectsTests
    {
        [TestMethod]
        public void TestCreateProj()
        {
            Generator generator = new Generator();
            generator.GenCode(ProjectMetadataHelper.TestProjectMetadata());
        }

        [TestMethod("WdScriptProject")]
        public void TestCreateWdScriptProject()
        {
            Generator generator = new Generator();
            generator.Settings.GenBllProject = false;
            generator.Settings.GenDalProject = false;
            generator.Settings.GenTestsProject = false;
            generator.Settings.GenWebApiProject = false;
            generator.Settings.GenReactProject = false;
            generator.Settings.GenSqlCommandProject = false;
            generator.Settings.GenSolution = false;
            generator.GenCode(ProjectMetadataHelper.WdScriptProjectMetadata());
        }

        [TestMethod("WdScriptSerializeModelProject")]
        public void TestCreateWdScriptSerializeModelProject()
        {
            Generator generator = new Generator();
            generator.Settings.GenBllProject = false;
            generator.Settings.GenDalProject = false;
            generator.Settings.GenTestsProject = false;
            generator.Settings.GenWebApiProject = false;
            generator.Settings.GenReactProject = false;
            generator.Settings.GenSqlCommandProject = false;
            generator.Settings.GenSolution = false;
            generator.GenCode(ProjectMetadataHelper.WdScriptSerilizeModelProjectMetadata());
        }

        [TestMethod("GeneratorGui")]
        public void TestCreateGeneratorGui()
        {
            Generator generator = new Generator();
            generator.Settings.GenWdScriptProject = false;
            generator.GenCode(ProjectMetadataHelper.GeneratorProjectMetadata());
        }

        [TestMethod]
        public void TestGui()
        {
            ProjectRunner.RunProject(ProjectMetadataHelper.GeneratorProjectMetadata());
        }

        [TestMethod("Corp")]
        public void TestCreateProjectCorp()
        {
            Generator generator = new Generator();
            generator.Settings.GenWdScriptProject = false;
            generator.Settings.GenSolution = false;
            generator.GenCode(ProjectMetadataHelper.ProjectMetadataCorp());
        }

        [TestMethod]
        public void TestCorp()
        {
            ProjectRunner.RunProject(ProjectMetadataHelper.ProjectMetadataCorp());
        }

        [TestMethod("ComplectationArm")]
        public void TestCreateComplectationArm()
        {
            Generator generator = new Generator();
            generator.GenCode(ProjectMetadataHelper.ComplectationArmProjectMetadata());
        }

        [TestMethod]
        public void TestComplectationArm()
        {
            ProjectRunner.RunProject(ProjectMetadataHelper.ComplectationArmProjectMetadata());
        }

        [TestMethod("RemakeArm")]
        public void TestCreateRemakeArm()
        {
            Generator generator = new Generator();
            generator.Settings.GenWdScriptProject = false;
            generator.GenCode(ProjectMetadataHelper.RemakeArmProjectMetadata());
        }


        [TestMethod]
        public void TestRemakeArm()
        {
            ProjectRunner.RunProject(ProjectMetadataHelper.RemakeArmProjectMetadata());

        }


        [TestMethod]
        public void TestLoadScripts()
        {
            List<ProjectMetadata> projects = LoadScriptService.GetScripts( new int[] { 10, 20, 30, 41, 42, 46, 47, 52, 53, 54, 55, 57, 58, 59, 63, 82, 84, 85, 87, 88, 70 });

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