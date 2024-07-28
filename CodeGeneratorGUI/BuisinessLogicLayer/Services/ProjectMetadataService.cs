using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using DataAccessLayer;
using DataAccessLayer.Dto;

namespace BuisinessLogicLayer.Services
{
    public class ProjectMetadataService : BaseService, IProjectMetadataService
    {
        public ProjectMetadataService(IUnitOfWork unit) : base(unit)
        {

        }

        public ProjectMetadata Add(ProjectMetadata projectMetadata)
        {
            Unit.RepProjectMetadata.Add(projectMetadata);

            return projectMetadata;
        }

        public IEnumerable<ProjectMetadata> Add(IEnumerable<ProjectMetadata> projectMetadata)
        {
            Unit.RepProjectMetadata.Add(projectMetadata);

            return projectMetadata;
        }

        public ProjectMetadata Get(int id)
        {
            ProjectMetadata t = Unit.RepProjectMetadata.GetById(id);

            return t;
        }

        public IEnumerable<ProjectMetadata> Get()
        {
            IEnumerable<ProjectMetadata> projectMetadatas = Unit.RepProjectMetadata.GetAll();

            return projectMetadatas;
        }

        public void Delete(int id)
        {
            Unit.RepProjectMetadata.Delete(id);
        }
    }
}
