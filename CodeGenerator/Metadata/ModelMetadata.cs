using CodeGenerator.Enum;

namespace CodeGenerator
{
    public class ModelMetadata
    {
        public string Name { get; set; }
        public string? NameSpace { get; set; }
        public string Caption { get; set; }
        public string? InitData { get; set; }
        public PropMetadata? PrimaryKeyProp => Props.FirstOrDefault(p => p.IsPrimaryKey);
        public PropMetadata? MasterProp => Props.FirstOrDefault(p => p.PropType == PropTypeEnum.Master);
        public List<PropMetadata> DictValueProps => Props.Where(p => p.PropType == PropTypeEnum.DictValue).ToList();
        public List<PropMetadata> DetailsProps => Props.Where(p => p.PropType == PropTypeEnum.Detail).ToList();
        public List<PropMetadata> VirtualProps => Props.Where(p => p.IsVirtual).ToList();
        public List<PropMetadata> Props { get; set; } = new List<PropMetadata>();
        public PropMetadata? GetProp(string typeName) => Props.FirstOrDefault(p => p.Name == typeName);
    }
}
