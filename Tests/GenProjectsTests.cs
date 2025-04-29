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
            Process hostApiProcess = ProjectRunner.BuildAndRunWebApi(ProjectMetadataHelper.ProjectMetadataCorp());
            Process hostClientProcess = ProjectRunner.BuildAndRunClient(ProjectMetadataHelper.ProjectMetadataCorp(), true);

            hostClientProcess.WaitForExit();
            hostApiProcess.WaitForExit();

            hostClientProcess.Kill();
            hostApiProcess.Kill();

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
            Process hostApiProcess = ProjectRunner.BuildAndRunWebApi(ProjectMetadataHelper.ComplectationArmProjectMetadata());
            Process hostClientProcess = ProjectRunner.BuildAndRunClient(ProjectMetadataHelper.ComplectationArmProjectMetadata(), true);

            hostClientProcess.WaitForExit();
            hostApiProcess.WaitForExit();

            hostClientProcess.Kill();
            hostApiProcess.Kill();

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
            Process hostApiProcess = ProjectRunner.BuildAndRunWebApi(ProjectMetadataHelper.RemakeArmProjectMetadata());
            Process hostClientProcess = ProjectRunner.BuildAndRunClient(ProjectMetadataHelper.RemakeArmProjectMetadata(), true);

            hostClientProcess.WaitForExit();
            hostApiProcess.WaitForExit();

            hostClientProcess.Kill();
            hostApiProcess.Kill();

        }
    }
}