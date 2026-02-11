
namespace CodeGenerator
{
    public class SharpClassProperty
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;

        private string GetType(string code)
        {
            string res = Code.Substring(Code.IndexOf("public") + 7);

            res = res.Trim().Substring(0, res.IndexOf(' '));

            return res;
        }

        public SharpClassProperty(string name, string code)
        {
            Name = name;
            Code = code;
            Type = GetType(Code);
        }
    }
}