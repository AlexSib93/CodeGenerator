using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using DataAccessLayer;
using DataAccessLayer.Dto;

namespace BuisinessLogicLayer.Services
{
    public class FormMetadataService : BaseService, IFormMetadataService
    {
        public FormMetadataService(IUnitOfWork unit) : base(unit)
        {

        }

        public FormMetadata Add(FormMetadata formMetadata)
        {
            Unit.RepFormMetadata.Add(formMetadata);

            return formMetadata;
        }

        public IEnumerable<FormMetadata> Add(IEnumerable<FormMetadata> formMetadata)
        {
            Unit.RepFormMetadata.Add(formMetadata);

            return formMetadata;
        }

        public FormMetadata Get(int id)
        {
            FormMetadata t = Unit.RepFormMetadata.GetById(id);

            return t;
        }

        public IEnumerable<FormMetadata> Get()
        {
            IEnumerable<FormMetadata> formMetadatas = Unit.RepFormMetadata.GetAll();

            return formMetadatas;
        }

        public void Delete(int id)
        {
            Unit.RepFormMetadata.Delete(id);
        }
    }
}
