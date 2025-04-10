using CodeGenerator.Interfaces;
using CodeGenerator.ProjectFiles.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.ProjectFiles.Sql
{
    public class SqlClass: IGenerator
    {
        public string SqlCommand;
        public SqlClass(string sqlCommand)
        {
            SqlCommand = sqlCommand;
        }
        public string Gen()
        {
            return $"{SqlCommand}";
        }
    }
}
