using CodeGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.CSharp.Class
{
    public class TsApiClass : IClass
    {
        public string Name { get; set; }
        public string ParamName => StringHelper.ToLowerFirstChar(ClassInfo.ModelName);
        public TsApiClass(ClassModelMetaInfo classInfo)
        {
            ClassInfo = classInfo;
        }

        public ClassModelMetaInfo ClassInfo { get; set; }

        public string Header => $@"{UsingText}";
        public string Body => $@"class {ClassInfo.ModelName}Service {{
{CreateOperationText()}

{GetOperationText()}
  
}}";

        private object GetOperationText()
        {
            string param = "id" + ClassInfo.ModelName;

            return $@"  get({param}: int): Promise<{ClassInfo.ModelName}> {{
    return ApiDataService.get('{ClassInfo.ModelName.ToLower()}', `get?{param}=${{{param}}}`)
      .then(
        (response) => Promise.resolve(response.data),
        (message) => Promise.reject(message)
      );
  }}";
        }

        private object CreateOperationText()
        {
            return $@"  post({ParamName}:{ClassInfo.ModelName}) {{
    return ApiDataService.post('{ClassInfo.ModelName.ToLower()}', 'create', {ParamName})
      .then((response: any) => {{
        return Promise.resolve(response.data);
      }},
        (message) => Promise.reject(message));
  }}";
        }


        public string UsingText => $@"import {{ {ClassInfo.ModelName}, init{ClassInfo.ModelName} }} from ""../models/{ClassInfo.ModelName.ToLower()}"";
import ApiDataService from ""./ApiDataService"";";

        public string Footer => $@"export default new {ClassInfo.ModelName}Service();";

        public string Render() => $@"{Header}

{Body}

{Footer}";
    
}
}
