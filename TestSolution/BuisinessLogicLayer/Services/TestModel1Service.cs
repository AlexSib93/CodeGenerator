using System;
using System.Collections.Generic;
using DataAccessLayer;
using DataAccessLayer.Dto;

namespace BuisinessLogicLayer.Services
{
    public class TestModel1Service : BaseService, ITestModel1Service
    {
        public TestModel1Service(IUnitOfWork unit) : base(unit)
        {
        }

        public TestModel1 Add(TestModel1 testModel1)
        {
            Unit.RepTestModel1.Add(testModel1);

            return testModel1;
        }

        public TestModel1 Get(int id)
        {
            TestModel1 t = Unit.RepTestModel1.GetById(id);

            return t;
        }

        public IEnumerable<TestModel1> Get()
        {
            IEnumerable<TestModel1> testModel1s = Unit.RepTestModel1.GetAll();

            return testModel1s;
        }

        public void Delete(int id)
        {
            Unit.RepTestModel1.Delete(id);
        }
    }
}
