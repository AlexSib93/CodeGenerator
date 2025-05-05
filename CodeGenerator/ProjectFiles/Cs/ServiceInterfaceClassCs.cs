using CodeGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.ProjectFiles.Cs
{
    public class ServiceInterfaceClassCs : IClass, IGenerator
    {
        public string Name { get; set; }
        public string ParamName => StringHelper.ToLowerFirstChar(ClassInfo.Name);
        public ServiceInterfaceClassCs(ModelMetadata classInfo)
        {
            ClassInfo = classInfo;
        }

        public ModelMetadata ClassInfo { get; set; }

        public string Header => $@"{UsingText}";
        public string Body => $@"namespace BuisinessLogicLayer.Services
{{
    public interface I{ClassInfo.Name}Service
    {{

{CreateOperationText()}

{UpdateOperationText()} 

{UpdateManyOperationText()}
{((ClassInfo.MasterProp != null) ? Environment.NewLine + UpdateByMaster() + Environment.NewLine : "")}
{GetOperationText()}

{GetAllOperationText()}
{((ClassInfo.MasterProp != null) ? Environment.NewLine + GetByMaster() + Environment.NewLine : "")}

{DeleteOperationText()}
    }}
}}
";

        private object UpdateByMaster()
        {
            string res = $@"        IEnumerable<{ClassInfo.Name}> Update(int idMaster, IEnumerable<{ClassInfo.Name}> {ParamName}s);";

            return res;
        }

        private object GetByMaster()
        {
            string res = $@"        IEnumerable<{ClassInfo.Name}> GetByMaster(int idMaster);";

            return res;
        }

        private string CreateOperationText()
        {
            string res = $@"        {ClassInfo.Name} Add({ClassInfo.Name} {ParamName});";

            return res;
        }
        

        private string UpdateOperationText()
        {
            string res = $@"        {ClassInfo.Name} Update({ClassInfo.Name} {ParamName});";

            return res;
        }

        private string UpdateManyOperationText()
        {
            string res = $@"        IEnumerable<{ClassInfo.Name}> Update(IEnumerable<{ClassInfo.Name}> {ParamName}s);";

            return res;
        }

        private string GetOperationText()
        {
            string param = ClassInfo.Name.Substring(0, 1).ToLower();
            string res = $@"        {ClassInfo.Name} Get(Expression<Func<{ClassInfo.Name}, bool>> where = null);";

            return res;
        }

        private string DeleteOperationText()
        {
            string param = ClassInfo.Name.Substring(0, 1).ToLower();
            string res = $@"        void Delete(int id);";

            return res;
        }

        private string GetAllOperationText()
        {
            string param = ParamName + "s";
            string res = $@"        IEnumerable<{ClassInfo.Name}> GetAll(Expression<Func<{ClassInfo.Name}, bool>> where = null);";

            return res;
        }

        public string Gen()
        {
            return $"{Header}\n\n{Body}";
        }

        public string UsingText => $@"using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DataAccessLayer;
using DataAccessLayer.Dto;";

    }
}
