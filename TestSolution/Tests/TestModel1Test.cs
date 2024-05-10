using BuisinessLogicLayer.Services;
using DataAccessLayer.Data;
using DataAccessLayer.Dto;

namespace Tests
{

    [TestClass]
    public class TestModel1Test
    {
        [TestMethod("Создать и Получить все позиции")]
        public void SetAndGetPositions()
        {
            var service = new TestModel1Service(new MockUnit());
            service.Add(new TestModel1());
            service.Add(new TestModel1());
            IEnumerable<TestModel1> l = service.Get();
            Assert.IsTrue(l.Any());
        }
    }
}
