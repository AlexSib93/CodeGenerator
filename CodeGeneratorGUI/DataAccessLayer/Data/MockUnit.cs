using System;
using DataAccessLayer.Dto;

namespace DataAccessLayer.Data
{
    public class MockUnit : IUnitOfWork, IDisposable
    {

        private IRepository<ModelMetadata> _repModelMetadata;
        public IRepository<ModelMetadata> RepModelMetadata
        {
            get { return _repModelMetadata ?? (_repModelMetadata = new MockRepository<ModelMetadata>()); }
        }

        private IRepository<ProjectMetadata> _repProjectMetadata;
        public IRepository<ProjectMetadata> RepProjectMetadata
        {
            get { return _repProjectMetadata ?? (_repProjectMetadata = new MockRepository<ProjectMetadata>()); }
        }

        private IRepository<FormMetadata> _repFormMetadata;
        public IRepository<FormMetadata> RepFormMetadata
        {
            get { return _repFormMetadata ?? (_repFormMetadata = new MockRepository<FormMetadata>()); }
        }

        private IRepository<PropMetadata> _repPropMetadata;
        public IRepository<PropMetadata> RepPropMetadata
        {
            get { return _repPropMetadata ?? (_repPropMetadata = new MockRepository<PropMetadata>()); }
        }


        public void Dispose()
        {
        }
    }
}
