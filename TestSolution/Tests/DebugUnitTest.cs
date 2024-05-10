using BuisinessLogicLayer.Services;
using DataAccessLayer.Data;
using DataAccessLayer.Dto;

namespace Tests
{

    [TestClass]
    public class DebugUnitTest
    {
        [TestMethod("Создать и Получить все позиции")]
        public void SetAndGetPositions()
        {
            var service = new DebugUnitService(new MockUnit());
            service.Add(new DebugUnit());
            service.Add(new DebugUnit());
            IEnumerable<DebugUnit> l = service.Get();
            Assert.IsTrue(l.Any());
        }
    }
}
