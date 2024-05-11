using System;
using System.Collections.Generic;
using DataAccessLayer;
using DataAccessLayer.Dto;

namespace BuisinessLogicLayer.Services
{
    public class ModelMetadataService : BaseService, IModelMetadataService
    {
        public ModelMetadataService(IUnitOfWork unit) : base(unit)
        {
        }

        public ModelMetadata Add(ModelMetadata modelMetadata)
        {
            Unit.RepModelMetadata.Add(modelMetadata);

            return modelMetadata;
        }

        public ModelMetadata Get(int id)
        {
            ModelMetadata t = Unit.RepModelMetadata.GetById(id);

            return t;
        }

        public IEnumerable<ModelMetadata> Get()
        {
            IEnumerable<ModelMetadata> modelMetadatas = Unit.RepModelMetadata.GetAll();

            return modelMetadatas;
        }

        public void Delete(int id)
        {
            Unit.RepModelMetadata.Delete(id);
        }
    }
}
