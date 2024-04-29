using DataAccessLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data
{
    public class MockUnit : IUnitOfWork, IDisposable
    {
        private IRepository<TestModel1> _repTestModel1;
        public IRepository<TestModel1> RepTestModel1
        {
            get { return _repTestModel1 ?? (_repTestModel1 = new MockRepository<TestModel1>()); }
        }

        public void Dispose()
        {
        }
    }
}
