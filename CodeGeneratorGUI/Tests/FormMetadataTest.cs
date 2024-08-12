using BuisinessLogicLayer.Services;
using DataAccessLayer.Data;
using DataAccessLayer.Dto;

namespace Tests
{

    [TestClass]
    public class FormMetadataTest
    {
        [TestMethod("Создать и Получить все позиции")]
        public void SetAndGetPositions()
        {
            var service = new FormMetadataService(new MockUnit());
            service.Add(new FormMetadata());
            service.Add(new FormMetadata());
            IEnumerable<FormMetadata> l = service.Get();
            Assert.IsTrue(l.Any());
        }
    }
}
