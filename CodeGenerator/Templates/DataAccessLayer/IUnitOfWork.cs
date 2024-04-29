using DataAccessLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TestModel1> RepTestModel1 { get;}

    }
}
