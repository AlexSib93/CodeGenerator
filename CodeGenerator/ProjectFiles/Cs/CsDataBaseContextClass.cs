using CodeGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.ProjectFiles.Cs
{
    public class CsDataBaseContextClass : IClass, IGenerator
    {
        public string Name { get; set; }
        public CsDataBaseContextClass(List<ModelMetadata> models)
        {
            Models = models;
        }

        public ModelMetadata ClassInfo { get; set; }
        public List<ModelMetadata> Models { get; set; }

        public string Header => $@"{UsingText}";
        public string Body => $@"namespace DataAccessLayer.Data
{{
    public class DataBaseContext: DbContext
    {{

{GetModelsText(Models)}

        public DataBaseContext(string connectionString)
           : base(new DbContextOptionsBuilder<DataBaseContext>().UseSqlServer(connectionString).Options)
        {{
        }}

        public DataBaseContext()
        {{
        }}

        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {{
        }}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {{
            if (!optionsBuilder.IsConfigured)
            {{
                optionsBuilder.UseSqlServer(""TestConnectionString"");
            }}
        }}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {{

        }}

    }}
}}

";

        public string UsingText => $@"using DataAccessLayer.Dto;
using Microsoft.EntityFrameworkCore;";

        public string GetModelText(ModelMetadata classInfo)
        {
            string res = "";
            res += $@"
        public virtual DbSet<{classInfo.Name}> {classInfo.Name} {{ get; set; }} = null!;
";

            return res;
        }

        public string GetModelsText(List<ModelMetadata> classesInfo)
        {
            string res = "";
            //Auth
            res += GetModelText(new ModelMetadata() { Name = "User" });

            foreach (ModelMetadata classInfo in classesInfo)
            {
                res += $"{GetModelText(classInfo)}\n";

            }

            return res;
        }

        public string Gen()
        {
            return $"{Header}\n\n{Body}";
        }

    }
}
