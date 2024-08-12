using System;
using System.Collections.Generic;
using DataAccessLayer;
using DataAccessLayer.Dto;

namespace BuisinessLogicLayer.Services
{
    public interface IProjectMetadataService
    {

        ProjectMetadata Add(ProjectMetadata projectMetadata);

        ProjectMetadata Get(int id);

        IEnumerable<ProjectMetadata> Get();

        void Delete(int id);
    }
}
