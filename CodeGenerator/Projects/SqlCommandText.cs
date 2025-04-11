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
            string Name = "SqlCommandCreateTable";
            string projectPath = $@"{projectMetadata.Path}\{Name}";
            string code = "";
            foreach (ModelMetadata model in projectMetadata.Models)
            {
                if (model.Props.Count > 0)
                {
                    code += Environment.NewLine + GetSqlCommandText(model.Props, model.Name) + Environment.NewLine;

                }
            }
            Items.Add(new ProjectItem(this, new SqlClass(code), "Create Data Base", $"{projectPath}", "sql"));
        }

        private string GetSqlCommandText(List<PropMetadata> propMD, string name)
        {
            string sqlCommand = $"CREATE TABLE {name} " +
                        $"\n(";
            foreach (PropMetadata pM in propMD)
            {
                sqlCommand += $"\n  {((pM.IsVirtual) ? "Id" + pM.Name : pM.Name)} {GetSqlType(pM)} {GetPrimatyKey(pM.IsPrimaryKey)} {GetForeignKey(pM)} {GetNullOrNotNull(pM.Type)},";
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
                if (prop.Type.StartsWith("List"))
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
