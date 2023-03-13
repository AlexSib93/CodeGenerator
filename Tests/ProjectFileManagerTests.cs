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
            projMetadata.Classes = new List<ModelMetadata>() { testModel };
            mngr.SaveProject("test-proj", projMetadata);
        }

        [TestMethod]
        public void TestLoadProj()
        {
            var mngr = new ProjectFileManager("./projects");
            ProjectMetadata projMetadata = mngr.LoadProject("test-proj");
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