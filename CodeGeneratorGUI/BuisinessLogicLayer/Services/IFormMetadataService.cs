using System;
using System.Collections.Generic;
using DataAccessLayer;
using DataAccessLayer.Dto;

namespace BuisinessLogicLayer.Services
{
    public interface IFormMetadataService
    {

        FormMetadata Add(FormMetadata formMetadata);

        FormMetadata Get(int id);

        IEnumerable<FormMetadata> Get();

        void Delete(int id);
    }
}
