using System;
using DataAccessLayer.Dto;

namespace DataAccessLayer
{
    public interface IUnitOfWork : IDisposable
    {

        IRepository<TestModel1> RepTestModel1 { get;}

        IRepository<DebugUnit> RepDebugUnit { get;}


    }
}
