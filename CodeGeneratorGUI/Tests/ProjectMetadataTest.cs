using BuisinessLogicLayer.Services;
using DataAccessLayer.Data;
using DataAccessLayer.Dto;

namespace Tests
{

    [TestClass]
    public class ProjectMetadataTest
    {
        [TestMethod("Создать и Получить все позиции")]
        public void SetAndGetPositions()
        {
            var service = new ProjectMetadataService(new MockUnit());
            service.Add(new ProjectMetadata());
            service.Add(new ProjectMetadata());
            IEnumerable<ProjectMetadata> l = service.Get();
            Assert.IsTrue(l.Any());
        }
    }
}
