using CodeGenerator.Enum;
using CodeGenerator.Interfaces;
using CodeGenerator.Metadata;

namespace CodeGenerator.ProjectFiles.Sql
{
    public class CreateDataBaseScript: IGenerator
    {
        public ProjectMetadata Project { get; set; }
        public CreateDataBaseScript(ProjectMetadata project)
        {
            Project = project;
        }

        public string Gen()
        {
            string code = "";

            List<ModelMetadata> sortedByDependencyModels = SortModelsByDependency(Project.Models);
            List<ModelMetadata> descSortedByDependencyModels = new List<ModelMetadata>();
            descSortedByDependencyModels.AddRange(sortedByDependencyModels);
            descSortedByDependencyModels.Reverse();

            foreach (ModelMetadata model in descSortedByDependencyModels)
            {
                if (model.Props.Count > 0)
                {
                    code += DropTableCode(model.Name) + Environment.NewLine;

                }
            }

            foreach (ModelMetadata model in sortedByDependencyModels)
            {
                if (model.Props.Count > 0)
                {
                    code += Environment.NewLine + GetSqlCommandText(model.Props, model.Name) + Environment.NewLine;

                }
            }

            return code;
        }


        private List<ModelMetadata> SortModelsByDependency(List<ModelMetadata> models)
        {
            //Первые модели без виртульных полей
            List<ModelMetadata> res = models.Where(m => !m.Props.Any(p => p.IsVirtual)).ToList();

            List<ModelMetadata> otherModels = models.Except(res).ToList();
            while (otherModels.Count > 0)
            {
                foreach (ModelMetadata model in otherModels)
                {
                    IEnumerable<PropMetadata> virtualFields = model.Props.Where(p => p.IsVirtual && p.PropType != PropTypeEnum.Enum && !p.IsEnumerable && p.Type != model.Name);
                    if (!virtualFields.Any(p => !res.Any(m => m.Name == p.Type)))
                    {
                        res.Add(model);
                    }
                }

                otherModels = otherModels.Except(res).ToList();
            }

            return res;
        }

        private string GetSqlCommandText(List<PropMetadata> propMD, string name)
        {
            string sqlCommand = $"CREATE TABLE {name} " +
                        $"\n(";
            foreach (PropMetadata pM in propMD.Where(p => !p.IsEnumerable))
            {
                sqlCommand += $"\n  [{((pM.IsVirtual) ? "Id" + pM.Name : pM.Name)}] {GetSqlType(pM)} {GetPrimatyKey(pM.IsPrimaryKey)} {GetForeignKey(pM)} {((pM.IsNullable) ? "NULL" : "NOT NULL")},";
            }
            sqlCommand = sqlCommand.TrimEnd(',') + "\n)";

            return sqlCommand;
        }

        private static string GetPrimatyKey(bool primaryKey)
        {
            string res = "";
            if (primaryKey)
            {
                res = "PRIMARY KEY";
            }
            return res;
        }

        private static string DropTableCode(string tableName)
        {
            string res = $"DROP TABLE IF EXISTS [{tableName}]";

            return res;
        }

        private string GetForeignKey(PropMetadata pM)
        {
            string res = "";
            if (pM.IsVirtual)
            {
                ModelMetadata type = Project.GetType( pM.Type);
                if (type != null)
                {
                    PropMetadata pkPropReferenced = type.Props.FirstOrDefault(p => p.IsPrimaryKey);
                    if (pkPropReferenced != null)
                    {
                        res = $"REFERENCES {pM.Type} ({pkPropReferenced.Name})";
                    }
                }
            }

            return res;
        }

        private static object GetSqlType(PropMetadata prop)
        {
            string res = prop.Type;
            if (prop.IsVirtual || prop.PropType == PropTypeEnum.Enum)
            {
                //TODO: выйти на ключевое свойства
                res = "INT";
            }
            else
            {
                if (prop.IsEnumerable)
                {
                    string classOfArray = prop.TypeOfEnumerable;
                    res = "none"; // Вопрос с классами, в sql фиг сделаешь
                }
                else
                {
                    string type = (prop.IsNullable)
                        ? prop.TypeOfNullable
                        : prop.Type;

                    switch (type)
                    {
                        case "decimal":
                            res = "DECIMAL";
                            break;
                        case "int":
                            res = "INT";
                            if (prop.IsPrimaryKey)
                                res += " IDENTITY";
                            break;
                        case "int?":
                            res = "INT";
                            break;
                        case "DateTime":
                            res = "DATETIME";
                            break;
                        case "bool":
                            res = "BIT";
                            break;
                        case "string":
                            res = "VARCHAR(MAX)";
                            break;
                        default:
                            res = "None";
                            break;
                    }
                }
            }


            return res;
        }
    }
}
