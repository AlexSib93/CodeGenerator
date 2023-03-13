using CodeGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.CSharp.Class
{
    public class TsApiClass : IClass, IGenerator
    {
        public string Name { get; set; }
        public string ParamName => StringHelper.ToLowerFirstChar(ClassInfo.Name);
        public TsApiClass(ModelMetadata classInfo)
        {
            ClassInfo = classInfo;
        }

        public ModelMetadata ClassInfo { get; set; }

        public string Header => $@"{UsingText}";
        public string Body => $@"class {ClassInfo.Name}Service {{
{CreateOperationText()}

{GetOperationText()}
  
}}";

        private object GetOperationText()
        {
            string param = "id" + ClassInfo.Name;

            return $@"  get({param}: number): Promise<{ClassInfo.Name}> {{
    return ApiDataService.get('{ClassInfo.Name.ToLower()}', `get?{param}=${{{param}}}`)
      .then(
        (response) => Promise.resolve(response.data),
        (message) => Promise.reject(message)
      );
  }}";
        }

        private object CreateOperationText()
        {
            return $@"  post({ParamName}:{ClassInfo.Name}) {{
    return ApiDataService.post('{ClassInfo.Name.ToLower()}', 'create', {ParamName})
      .then((response: any) => {{
        return Promise.resolve(response.data);
      }},
        (message) => Promise.reject(message));
  }}";
        }


        public string UsingText => $@"import {{ {ClassInfo.Name}, init{ClassInfo.Name} }} from ""../models/{ClassInfo.Name.ToLower()}"";
import ApiDataService from ""./ApiDataService"";";

        public string Footer => $@"export default new {ClassInfo.Name}Service();";

        public string Gen()
        {
            return $"{Header}\n\n{Body}\n\n{Footer}";
        }
    }
}
