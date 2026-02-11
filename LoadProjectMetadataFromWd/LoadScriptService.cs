using CodeGenerator;
using CodeGenerator.Metadata;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadProjectMetadataFromWd
{
    public class LoadScriptService
    {
        //public static string ConnectionString { get; set; } = "Password=ggdhHGHGKdgett3563@#;Persist Security Info=True;User ID=windraw-dbo;Initial Catalog=ecad_copy;Data Source=sql-wd-01.corp.lan;";
        public static string ConnectionString { get; set; } = "Password = ggdhHGHGKdgett3563@#;Persist Security Info=True;User ID=windraw-dbo;Initial Catalog=ecad_steklodom;Data Source=sql-wd;";

        public static List<ProjectMetadata> GetScripts(int[] scriptIds)
        {
            List<ProjectMetadata> res = new List<ProjectMetadata>();

            string sql = @$"
SELECT 
      1 AS IsWdScript,
      m.name,
      CAST(m.idmodelscript as varchar(max)) + '_' AS Namespace,
      '..\..\..\..\Projects\std\Std.WdScripts\Std.WdScripts.CalcScripts\' AS Path,
      m.codescript as CodeScript 
FROM modelscript m 
WHERE m.idmodelscript IN @scriptIds
"; 

            using(SqlConnection conn = new SqlConnection(ConnectionString) )
            {
                res = conn.Query<ProjectMetadata>(sql, new { scriptIds }).ToList();
            }

            foreach(var item in res)
            {
                string formatedName = item.Name.Replace('-',' ').Replace('-', ' ').Replace('(', ' ').Replace(')', ' ').Replace('.', ' ').Replace(',', ' ').Replace(' ', '_').Replace("__", "_").Replace("__", "_");

                item.Name = item.Namespace + formatedName;
                item.Description = formatedName;
                item.Namespace = formatedName;
                //фикс скобок в одной строке с наименованием класса
                item.CodeScript = item.CodeScript.Replace("RunCalc{", "RunCalc" + Environment.NewLine + "        {");
                //удалить комментарии
                item.CodeScript = ClearCommentsWithStar(item.CodeScript);

                item.Models.Add(new ModelMetadata() { Name = formatedName + "Service", InitData = item.CodeScript });
            }


            return res;
        }

        public static List<ProjectMetadata> GetEvents(int[] scriptIds)
        {
            List<ProjectMetadata> res = new List<ProjectMetadata>();

            string sql = @$"
SELECT 
      1 AS IsWdScript,
      m.name,
      CAST(m.idorderevent as varchar(max)) + '_' AS Namespace,
      '..\..\..\..\Projects\std\Std.WdScripts\Std.WdScripts.DocumentEvent\' AS Path,
      m.codescript as CodeScript 
FROM orderevent m 
WHERE m.idorderevent IN @scriptIds
";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                res = conn.Query<ProjectMetadata>(sql, new { scriptIds }).ToList();
            }

            foreach (var item in res)
            {
                string formatedName = item.Name.Replace('-', ' ').Replace('-', ' ').Replace('(', ' ').Replace(')', ' ').Replace('.', ' ').Replace(',', ' ').Replace(' ', '_').Replace("__", "_").Replace("__", "_");

                item.Name = item.Namespace + formatedName;
                item.Description = formatedName;
                item.Namespace = formatedName;
                //фикс скобок в одной строке с наименованием класса
                item.CodeScript = item.CodeScript.Replace("RunCalc{", "RunCalc" + Environment.NewLine + "        {");
                //удалить комментарии
                item.CodeScript = ClearCommentsWithStar(item.CodeScript);


                item.Models.Add(new ModelMetadata() { Name = formatedName + "Service", InitData = item.CodeScript });
            }


            return res;
        }

        public static List<ProjectMetadata> GetExceptedScripts(int[] scriptIds)
        {
            List<ProjectMetadata> res = new List<ProjectMetadata>();

            string sql = @$"
SELECT 
      1 AS IsWdScript,
      m.name,
      CAST(m.idmodelscript as varchar(max)) + '_' AS Namespace,
      '..\..\..\..\Projects\std\Std.WdScripts\Std.WdScripts.CalcScripts\' AS Path,
      m.codescript as CodeScript 
FROM modelscript m 
WHERE m.idmodelscript NOT IN @scriptIds AND ISNULL(m.activescript, 0) = 1
";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                res = conn.Query<ProjectMetadata>(sql, new { scriptIds }).ToList();
            }

            foreach (var item in res)
            {
                string formatedName = item.Name.Replace('-', ' ').Replace('-', ' ').Replace('(', ' ').Replace(')', ' ').Replace('.', ' ').Replace(',', ' ').Replace(' ', '_').Replace("__", "_").Replace("__", "_");

                item.Name = item.Namespace + formatedName;
                item.Description = formatedName;
                item.Namespace = formatedName;
                //фикс скобок в одной строке с наименованием класса
                item.CodeScript = item.CodeScript.Replace("RunCalc{", "RunCalc" + Environment.NewLine + "        {");
                //удалить комментарии
                item.CodeScript = ClearCommentsWithStar(item.CodeScript);


                item.Models.Add(new ModelMetadata() { Name = formatedName + "Service", InitData = item.CodeScript });
            }


            return res;
        }

        public static List<ProjectMetadata> GetDesignerEvent()
        {
            List<ProjectMetadata> res = new List<ProjectMetadata>();

            string sql = @$"
 SELECT   1 AS IsWdScript,
      'DesignerEvent' as name,
      'DesignerEvent' AS Namespace,
      '..\..\..\..\Projects\std\Std.WdScripts\Std.WdScripts.DesignerEvent\' AS Path,
      codescript as CodeScript
FROM designerevent
";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                res = conn.Query<ProjectMetadata>(sql).ToList();
            }

            foreach (var item in res)
            {
                string formatedName = item.Name.Replace('-', ' ').Replace('-', ' ').Replace('+', ' ').Replace('(', ' ').Replace(')', ' ').Replace('.', ' ').Replace(',', ' ').Replace(' ', '_').Replace("__", "_").Replace("__", "_");

                item.Name = formatedName;
                item.Description = formatedName;
                item.Namespace = formatedName;
                //фикс скобок в одной строке с наименованием класса
                item.CodeScript = item.CodeScript.Replace("RunCalc{", "RunCalc" + Environment.NewLine + "        {");
                //удалить комментарии
                item.CodeScript = ClearCommentsWithStar(item.CodeScript);
                item.CodeScript = ClearComments(item.CodeScript);


                item.Models.Add(new ModelMetadata() { Name = formatedName + "Service", InitData = item.CodeScript });
            }


            return res;
        }

        public static string ClearCommentsWithStar(string codeScript)
        {
            string res = codeScript;

            while (res.IndexOf("/*") >=0)
            {
                int start = res.IndexOf("/*");
                int end = res.IndexOf("*/");

                if(start >= 0 && end >= 0)
                {
                    int len = end - start + 2;
                    res = res.Substring(0, start) + res.Substring(end + 2);
                }

            }

            return res;
        }

        public static string ClearComments(string codeScript)
        {
            var lines = codeScript.Split(Environment.NewLine);

            lines = lines.Where(l => !l.Trim().StartsWith("//")).ToArray();

            return string.Join(Environment.NewLine, lines);
        }
    }
}
