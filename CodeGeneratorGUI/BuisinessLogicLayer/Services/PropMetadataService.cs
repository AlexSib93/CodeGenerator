using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using DataAccessLayer;
using DataAccessLayer.Dto;

namespace BuisinessLogicLayer.Services
{
    public class PropMetadataService : BaseService, IPropMetadataService
    {
        public PropMetadataService(IUnitOfWork unit) : base(unit)
        {

        }

        public PropMetadata Add(PropMetadata propMetadata)
        {
            Unit.RepPropMetadata.Add(propMetadata);

            return propMetadata;
        }

        public IEnumerable<PropMetadata> Add(IEnumerable<PropMetadata> propMetadata)
        {
            Unit.RepPropMetadata.Add(propMetadata);

            return propMetadata;
        }

        public PropMetadata Get(int id)
        {
            PropMetadata t = Unit.RepPropMetadata.GetById(id);

            return t;
        }

        public IEnumerable<PropMetadata> Get()
        {
            IEnumerable<PropMetadata> propMetadatas = Unit.RepPropMetadata.GetAll();

            return propMetadatas;
        }

        public void Delete(int id)
        {
            Unit.RepPropMetadata.Delete(id);
        }
    }
}
