using System;

namespace DataAccessLayer.Dto
{
    public class ProjectMetadata
    {
      public string Name { get; set; }
      public string Description { get; set; }
      public string Path { get; set; }
      public List<ModelMetadata> Models { get; set; }
      public List<FormMetadata> Forms { get; set; }

    }
}
