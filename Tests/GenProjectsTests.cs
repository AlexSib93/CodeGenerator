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
    }
}