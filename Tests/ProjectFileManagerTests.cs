using CodeGenerator.Metadata;
using CodeGenerator;
using CodeGenerator.Services;

namespace Tests
{
    [TestClass]
    public class ProjectFileManagerTests
    {
        [TestMethod]
        public void TestCreateProj()
        {
            var mngr = new ProjectFileManager("./projects");
            ProjectMetadata projMetadata = new ProjectMetadata();
            ModelMetadata testModel= new ModelMetadata();
            testModel.Props = new List<PropMetadata>() { new PropMetadata() };
            projMetadata.Models = new List<ModelMetadata>() { testModel };
            mngr.SaveProject("test-proj", projMetadata);
        }

        [TestMethod]
        public void TestMigrateProjFromCode()
        {
            var mngr = new ProjectFileManager("./projects");
            mngr.SaveProject("test", ProjectMetadataHelper.TestProjectMetadata());
            mngr.SaveProject("corp", ProjectMetadataHelper.ProjectMetadataCorp());
            mngr.SaveProject("generator-gui", ProjectMetadataHelper.GeneratorProjectMetadata());
            mngr.SaveProject("remake-arm", ProjectMetadataHelper.RemakeArmProjectMetadata());
            mngr.SaveProject("compl-arm", ProjectMetadataHelper.ComplectationArmProjectMetadata());

            List<ProjectMetadata> list = mngr.GetProjects<ProjectMetadata>();
            ProjectMetadata corpProject = mngr.LoadProject<ProjectMetadata>("corp");
            ProjectMetadata generatorProject = mngr.LoadProject<ProjectMetadata>("generator-gui");

        }

        [TestMethod]
        public void TestLoadProj()
        {
            var mngr = new ProjectFileManager("./projects");
            ProjectMetadata projMetadata = mngr.LoadProject<ProjectMetadata>("test-proj");
        }

        [TestMethod]
        public void TestDeleteProj()
        {
            var mngr = new ProjectFileManager("./projects");
            mngr.DeleteProjectFile("test-proj");
        }

        [TestMethod]
        public void TestGetProjects()
        {
            var mngr = new ProjectFileManager("./projects");
            var projects = mngr.GetProjectFiles();

            Assert.IsTrue(projects.Any());
        }
    }
}