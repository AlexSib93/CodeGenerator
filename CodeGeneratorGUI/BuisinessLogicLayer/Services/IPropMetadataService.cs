using System;
using System.Collections.Generic;
using DataAccessLayer;
using DataAccessLayer.Dto;

namespace BuisinessLogicLayer.Services
{
    public interface IPropMetadataService
    {

        PropMetadata Add(PropMetadata propMetadata);

        PropMetadata Get(int id);

        IEnumerable<PropMetadata> Get();

        void Delete(int id);
    }
}
