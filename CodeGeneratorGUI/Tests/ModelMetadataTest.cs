using BuisinessLogicLayer.Services;
using DataAccessLayer.Data;
using DataAccessLayer.Dto;

namespace Tests
{

    [TestClass]
    public class ModelMetadataTest
    {
        [TestMethod("Создать и Получить все позиции")]
        public void SetAndGetPositions()
        {
            var service = new ModelMetadataService(new MockUnit());
            service.Add(new ModelMetadata());
            service.Add(new ModelMetadata());
            IEnumerable<ModelMetadata> l = service.Get();
            Assert.IsTrue(l.Any());
        }
    }
}
