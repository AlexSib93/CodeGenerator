using BuisinessLogicLayer.Services;
using DataAccessLayer.Data;
using DataAccessLayer.Dto;

namespace Tests
{

    [TestClass]
    public class PropMetadataTest
    {
        [TestMethod("Создать и Получить все позиции")]
        public void SetAndGetPositions()
        {
            var service = new PropMetadataService(new MockUnit());
            service.Add(new PropMetadata());
            service.Add(new PropMetadata());
            IEnumerable<PropMetadata> l = service.Get();
            Assert.IsTrue(l.Any());
        }
    }
}
