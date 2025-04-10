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
            foreach (ModelMetadata model in projectMetadata.Models)
            {
                if (model.Props.Count > 0)
                {
                    Items.Add(new ProjectItem(this, new SqlClass(GetSqlCommandText(model.Props, model.Name)), model.Name, $"{projectPath}", "sql"));
                }
            }
        }

        private static string GetSqlCommandText(List<PropMetadata> propMD, string name)
        {
            string sqlCommand = $"Create Table {name} " +
                        $"\n(";
            foreach (PropMetadata pM in propMD)
            {
                sqlCommand += $"\n{pM.Name} {GetSqlType(pM.Type)} {GetPrimatyKey(pM.PrimaryKey)} {GetForeightKey(pM)} {GetNullOrNotNull(pM.Type)},";
            }
            sqlCommand = sqlCommand.TrimEnd(',') + "\n)";

            return sqlCommand;
        }

        private static string GetNullOrNotNull(string type)
        {
            string res = "";
            if (!type.Contains("?"))
            {
                res = "Not NUll";
            }
            return res;
        }

        private static string GetPrimatyKey(bool primaryKey)
        {
            string res = "";
            if (primaryKey == true)
            {
                res = "PRIMARY KEY";
            }
            return res;
        }

        private static string GetForeightKey(PropMetadata pM)
        {
            string res = "";
            if (pM.ForeigthName != null && pM.ForeigthTable!=null)
            {
                res = $"REFERENCES {pM.ForeigthTable} ({pM.ForeigthName})";
            }
            return res;
        }

        private static object GetSqlType(string type)
        {
            string res = type;
            if (type.StartsWith("List"))
            {
                string classOfArray = type.Substring(type.IndexOf("<") + 1, type.IndexOf(">") - type.IndexOf("<") - 1);
                res = "none"; // Вопрос с классами, в sql фиг сделаешь
            }
            else
            {
                switch (type)
                {
                    case "decimal":
                        res = "decimal";
                        break;
                    case "int":
                        res = "int";
                        break;
                    case "int?":
                        res = "int";
                        break;
                    case "DateTime":
                        res = "DateTime";
                        break;
                    case "bool":
                        res = "BIT";
                        break;
                    case "string":
                        res = "varchar(max)";
                        break;
                    default:
                        res = "None";
                        break;
                }
            }

            return res;
        }
    }
}
