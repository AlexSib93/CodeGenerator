using System;
using DataAccessLayer.Dto;

namespace DataAccessLayer.Data
{
    public class MockUnit : IUnitOfWork, IDisposable
    {

        private IRepository<TestModel1> _repTestModel1;
        public IRepository<TestModel1> RepTestModel1
        {
            get { return _repTestModel1 ?? (_repTestModel1 = new MockRepository<TestModel1>()); }
        }

        private IRepository<DebugUnit> _repDebugUnit;
        public IRepository<DebugUnit> RepDebugUnit
        {
            get { return _repDebugUnit ?? (_repDebugUnit = new MockRepository<DebugUnit>()); }
        }


        public void Dispose()
        {
        }
    }
}
