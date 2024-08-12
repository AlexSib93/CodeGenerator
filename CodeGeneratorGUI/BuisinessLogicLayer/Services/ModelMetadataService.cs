using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using DataAccessLayer;
using DataAccessLayer.Dto;

namespace BuisinessLogicLayer.Services
{
    public class ModelMetadataService : BaseService, IModelMetadataService
    {
        public ModelMetadataService(IUnitOfWork unit) : base(unit)
        {
Add(JsonConvert.DeserializeObject<IEnumerable<ModelMetadata>>(@"[
  {
    ""Name"": ""ModelMetadata"",
    ""NameSpace"": ""CodeGeneratorGUI"",
    ""Caption"": ""Модель"",
    ""Props"": [
      {
        ""Name"": ""Name"",
        ""Type"": ""string"",
        ""Caption"": ""Имя""
      },
      {
        ""Name"": ""Description"",
        ""Type"": ""string"",
        ""Caption"": ""Описание""
      },
      {
        ""Name"": ""Id"",
        ""Type"": ""int"",
        ""Caption"": ""Идентификатор""
      }
    ]
  },
  {
    ""Name"": ""ProjectMetadata"",
    ""NameSpace"": ""CodeGeneratorGUI"",
    ""Caption"": ""Проект"",
    ""Props"": null
  },
  {
    ""Name"": ""FormMetadata"",
    ""NameSpace"": ""CodeGeneratorGUI"",
    ""Caption"": ""Форма"",
    ""Props"": null
  }
]"));
        }

        public ModelMetadata Add(ModelMetadata modelMetadata)
        {
            Unit.RepModelMetadata.Add(modelMetadata);

            return modelMetadata;
        }

        public IEnumerable<ModelMetadata> Add(IEnumerable<ModelMetadata> modelMetadata)
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
