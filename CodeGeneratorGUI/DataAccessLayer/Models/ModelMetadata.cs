using System;

namespace DataAccessLayer.Dto
{
    public class ModelMetadata
    {
      public string Name { get; set; }
      public string NameSpace { get; set; }
      public string Caption { get; set; }
      public List<PropMetadata> Props { get; set; }

    }
}
