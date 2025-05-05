using CodeGenerator.Interfaces;
using CodeGenerator.Metadata;
using CodeGenerator.ProjectFiles.Cs;
using CodeGenerator.ProjectFiles.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CodeGenerator.Projects
{
    public class SqlCommandText : Project, IProject
    {
        public SqlCommandText(ProjectMetadata projectMetadata) : base(projectMetadata)
        {
            Name = "SqlCommand";
            string projectPath = $@"{projectMetadata.Path}\{Name}";
            string code = "";

            List<ModelMetadata> sortedByDependencyModels = SortModelsByDependency(projectMetadata.Models);
            List<ModelMetadata> descSortedByDependencyModels = new List<ModelMetadata>();
            descSortedByDependencyModels.AddRange( sortedByDependencyModels);
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
            Items.Add(new ProjectItem(this, new SqlClass(code), "Create Data Base", $"{projectPath}", "sql"));
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
                    IEnumerable<PropMetadata> virtualFields = model.Props.Where(p => p.IsVirtual && !p.IsEnumerable && p.Type != model.Name);
                    if (!virtualFields.Any(p => !res.Any(m=> m.Name == p.Type)))
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
            foreach (PropMetadata pM in propMD.Where(p=>!p.IsEnumerable))
            {
                sqlCommand += $"\n  [{((pM.IsVirtual) ? "Id" + pM.Name : pM.Name)}] {GetSqlType(pM)} {GetPrimatyKey(pM.IsPrimaryKey)} {GetForeignKey(pM)} {GetNullOrNotNull(pM.Type)},";
            }
            sqlCommand = sqlCommand.TrimEnd(',') + "\n)";

            return sqlCommand;
        }

        private static string GetNullOrNotNull(string type)
        {
            string res = "";
            if (!type.Contains("?"))
            {
                res = "NOT NULL";
            }
            return res;
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
                ModelMetadata type = Metadata.Models.FirstOrDefault(m => m.Name == pM.Type);
                if(type != null)
                {
                    PropMetadata pkPropReferenced = type.Props.FirstOrDefault(p => p.IsPrimaryKey);
                    if(pkPropReferenced != null)
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
            if(prop.IsVirtual)
            {
                //TODO: выйти на ключевое свойства
                res = "INT";
            }
            else
            {
                if (prop.IsEnumerable)
                {
                    string classOfArray = prop.Type.Substring(prop.Type.IndexOf("<") + 1, prop.Type.IndexOf(">") - prop.Type.IndexOf("<") - 1);
                    res = "none"; // Вопрос с классами, в sql фиг сделаешь
                }
                else
                {
                    switch (prop.Type)
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
