using CodeGenerator.Interfaces;
using CodeGenerator.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.ProjectFiles.Cs
{
    public class CsServiceClass : IClass, IGenerator
    {
        public string Name { get; set; }
        public string ParamName => StringHelper.ToLowerFirstChar(ClassInfo.Name);
        public ProjectMetadata Project { get; set; }
        public CsServiceClass(ModelMetadata classInfo, ProjectMetadata project)
        {
            ClassInfo = classInfo;
            Project = project;
        }

        public ModelMetadata ClassInfo { get; set; }

        public string Header => $@"{UsingText}";
        public string Body => $@"namespace BuisinessLogicLayer.Services
{{
    public class {ClassInfo.Name}Service : BaseService, I{ClassInfo.Name}Service
    {{
{GetConstructorText()}

{CreateOperationText()}

{UpdateOperationText()}

{CreateManyOperationText()}

{GetOperationText()}

{GetAllOperationText()}

{DeleteOperationText()}
    }}
}}
";

        private string GetConstructorText()
        {
            string res = $@"        public {ClassInfo.Name}Service(IUnitOfWork unit) : base(unit)
        {{
{GetInitDataText()}
        }}";

            return res;
        }

        public string GetInitDataText()
        {
            string res = "";

            if (!string.IsNullOrEmpty(ClassInfo.InitData))
            {
                res = $@"Add(JsonConvert.DeserializeObject<IEnumerable<{ClassInfo.Name}>>(@""{ClassInfo.InitData.Replace("\"","\"\"")}""));";
            }

            return res;
        }

        private string CreateOperationText()
        {
            string res = $@"        public {ClassInfo.Name} Add({ClassInfo.Name} {ParamName})
        {{
            Unit.Rep{ClassInfo.Name}.Add({ParamName});

            return {ParamName};
        }}";

            return res;
        }

        private string UpdateOperationText()
        {
            string res = $@"        public {ClassInfo.Name} Update({ClassInfo.Name} {ParamName})
        {{
            int res = Unit.Rep{ClassInfo.Name}.Update({ParamName});

            return {ParamName};
        }}";

            return res;
        }

        private string CreateManyOperationText()
        {
            string res = $@"        public IEnumerable<{ClassInfo.Name}> Add(IEnumerable<{ClassInfo.Name}> {ParamName})
        {{
            Unit.Rep{ClassInfo.Name}.Add({ParamName});

            return {ParamName};
        }}";

            return res;
        }

        private string GetOperationText()
        {
            string param = ClassInfo.Name.Substring(0, 1).ToLower();
            IEnumerable<PropMetadata> virtualProps = ClassInfo.Props.Where(p => p.IsVirtual);
            string includesString = IncludesString(virtualProps);
            string res = $@"        public {ClassInfo.Name} Get(Expression<Func<{ClassInfo.Name}, bool>> where = null)
        {{
            {ClassInfo.Name} t = Unit.Rep{ClassInfo.Name}.Get(where{includesString});

            return t;
        }}";

            return res;
        }

        private string IncludesString(IEnumerable<PropMetadata> virtualProps)
        {
            //ModelMetadata metadata = new ModelMetadata();

            List<string> includesPropsString = new List<string>();
            foreach (PropMetadata virtProp in virtualProps)
            {
                includesPropsString.Add(virtProp.Name);
                if (virtProp.IsDetailsProp)
                {
                    ModelMetadata virtType = Project.GetType(virtProp.TypeOfEnumerable);
                    List<PropMetadata> virtPropsOfVirtProp = virtType.Props.Where(p => p.IsDictValueProp).ToList();
                    foreach (PropMetadata virtPropsOfVirtPropMetadata in virtPropsOfVirtProp)
                    {
                        includesPropsString.Add(virtProp.Name + "." + virtPropsOfVirtPropMetadata.Name);
                    }
                    //if (virtType != null)
                    //{
                    //    foreach (PropMetadata pr in virtType.Props.Where(p => p.IsDictValueProp).ToList())
                    //    {
                    //        includesPropsString.Add(virtProp.Name + "." + pr.Name);
                    //    }
                    //}
                }

            }

            string res = "";
            if(virtualProps.Any())
            {
                res = ", " + string.Join(", ", includesPropsString.Select(s => $@"""{ s}""") ) ;
            }

            return res;
        }

        private string DeleteOperationText()
        {
            string param = ClassInfo.Name.Substring(0, 1).ToLower();
            string res = $@"        public void Delete(int id)
        {{
            {ClassInfo.Name} t = Unit.Rep{ClassInfo.Name}.Get(p => p.{ClassInfo.Props.FirstOrDefault(p => p.IsPrimaryKey)?.Name}==id);
            Unit.Rep{ClassInfo.Name}.Delete(t);
        }}";

            return res;
        }

        private string GetAllOperationText()
        {
            string param = ParamName + "s";
            IEnumerable<PropMetadata> virtualProps = ClassInfo.Props.Where(p => p.IsMasterProp);

            string includesString = (virtualProps.Any())
                ? "where," + string.Join(", ", virtualProps.Select(p => $"\"{p.Name}\""))
                : "where";
            string res = $@"        public IEnumerable<{ClassInfo.Name}> GetAll(Expression<Func<{ClassInfo.Name}, bool>> where = null)
        {{
            IEnumerable<{ClassInfo.Name}> {param} = Unit.Rep{ClassInfo.Name}.GetAll({includesString});

            return {param};
        }}";

            return res;
        }

        public string Gen()
        {
            return $"{Header}\n\n{Body}";
        }

        public string UsingText => $@"using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Newtonsoft.Json;
using DataAccessLayer;
using DataAccessLayer.Dto;";

    }
}
