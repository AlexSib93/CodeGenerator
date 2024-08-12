using System;
using System.Collections.Generic;
using DataAccessLayer;
using DataAccessLayer.Dto;

namespace BuisinessLogicLayer.Services
{
    public interface IModelMetadataService
    {

        ModelMetadata Add(ModelMetadata modelMetadata);

        ModelMetadata Get(int id);

        IEnumerable<ModelMetadata> Get();

        void Delete(int id);
    }
}
