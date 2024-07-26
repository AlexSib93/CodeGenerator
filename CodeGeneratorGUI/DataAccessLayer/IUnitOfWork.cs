using System;
using DataAccessLayer.Dto;

namespace DataAccessLayer
{
    public interface IUnitOfWork : IDisposable
    {

        IRepository<ModelMetadata> RepModelMetadata { get;}

        IRepository<ProjectMetadata> RepProjectMetadata { get;}

        IRepository<FormMetadata> RepFormMetadata { get;}

        IRepository<PropMetadata> RepPropMetadata { get;}

        IRepository<User> RepUser { get;}


    }
}
