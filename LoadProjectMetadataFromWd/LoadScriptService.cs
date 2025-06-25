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
        public static string ConnectionString { get; set; } = "Password=ggdhHGHGKdgett3563@#;Persist Security Info=True;User ID=windraw-dbo;Initial Catalog=ecad_copy;Data Source=sql-wd-01.corp.lan;";

        public static List<ProjectMetadata> GetScripts(int[] scriptIds)
        {
            List<ProjectMetadata> res = new List<ProjectMetadata>();

            string sql = @$"
SELECT 
      1 AS IsWdScript,
      CAST(m.idmodelscript AS VARCHAR(MAX)) + '_'+ REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(name, '_', ' '), '(', ' '), ')', ' '), '.', ' '), '  ', '_'), '  ', '_'), ' ', '_') AS Name,
      REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(name, '_', ' '), '(', ' '), ')', ' '), '.', ' '), '  ', ' '), '  ', ' '), ' ', '_') AS Namespace,
      '..\..\..\..\Projects\std\Std.WdScripts\Std.WdScripts.CalcScripts\' AS Path,
      REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(name, '_', ' '), '(', ' '), ')', ' '), '.', ' '), '  ', ' '), '  ', ' '), ' ', '_') +'Service' AS Description,
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
                item.CodeScript = item.CodeScript.Replace("RunCalc{", "RunCalc" + Environment.NewLine + "        {");
                item.Models.Add(new ModelMetadata() { Name = item.Description, InitData = item.CodeScript });
            }


            return res;
        }
    }
}
