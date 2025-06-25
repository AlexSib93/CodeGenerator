using CodeGenerator.Enum;

namespace CodeGenerator.Metadata
{
    public class ProjectMetadata
    {
        public string Name { get; set; }
        public string Caption { get; set; }
        public string? Namespace { get; set; }
        public string? Description { get; set; }
        public string? Path { get; set; }
        public string? DbConnectionString { get; set; }
        public bool IsWdScript { get; set; } = false;
        public string CodeScript { get; set; }

        // Todo: переделать на enum
        public UnitOfWorkEnum UnitOfWork { get; set; } = UnitOfWorkEnum.MockUnit;
        public int? WebApiHttpsPort { get; set; } = 7112;
        public int? DevServerPort { get; set; } = 3000;
        public List<ModelMetadata> Models { get; set; } = new List<ModelMetadata>();
        public List<FormMetadata> Forms { get; set; } = new List<FormMetadata>();
        public List<EnumMetadata> EnumTypes { get; set; } = new List<EnumMetadata> { };

        public ModelMetadata? GetType(string typeName) => Models.FirstOrDefault(m => m.Name == typeName);
        public EnumMetadata? GetEnumType(string typeName) => EnumTypes.FirstOrDefault(m => m.Name == typeName);
    }
}
