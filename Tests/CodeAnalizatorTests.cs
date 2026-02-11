using CodeGenerator.Metadata;
using CodeGenerator;
using CodeGenerator.Services;
using CodeGenerator.Projects;
using System.Diagnostics;
using System.Net.NetworkInformation;
using LoadProjectMetadataFromWd;

namespace Tests
{
    [TestClass]
    public class GenProjectsTests
    {
        [TestMethod]
        public void TestCodeAnalizator2()
        {

            var codeAnalizator = new SharpCodeAnalizator(CodeForAnalize.OrderItemFieldsCode, CodeGenerator.Enum.CodeLanguageEnum.Sharp, true);

            var propsForChange = codeAnalizator.Classes.FirstOrDefault()?.Props;

            foreach (SharpClassProperty p in propsForChange)
            {
                //p.Code = p.Code.Substring(0, p.Code.IndexOf(Environment.NewLine)) + " { get; set; }";
                p.Code = $@"        private {p.Type} {p.Name.ToLower()};
        public {p.Type} {p.Name} 
        {{ 
            get => {p.Name.ToLower()};
            set 
            {{
                if (value != null)
                {{
                    OrderItemRow.{p.Name} = ({p.Type.Trim('?')})value;
                }}
                else
                {{
                    OrderItemRow.Set{p.Name.ToLower()}Null();
                }}
                {p.Name.ToLower()} = value;
            }} 
        }}";
                //            p.Code = p.Code.Replace(p.Name + " {", StringHelper.ToUpperFirstChar(p.Name) + " {");
                //            p.Code = p.Code.Replace($@"set {{"
                //                , $@"set
                //            {{
                //                lock (Table)
                //                {{
                //                    Table.BeginLoadData();
                //                    try
                //                    {{");

                //            p.Code = p.Code.Replace($@" = value;", $@" = value;
                //                    }}
                //                    finally
                //                    {{
                //                        Table.EndLoadData();
                //                    }}
                //                }}");

                //            p.Code = p.Code.Replace($@"get {{", $@"get {{
                //                lock (Table)
                //                {{");
                //            p.Code = p.Code.Replace($@"    }}
                //set", $@"    }}
                //            }}
                //set");


            }

            string res = string.Join(Environment.NewLine + Environment.NewLine, propsForChange.Select(p => p.Code));
        }

        [TestMethod]
        public void TestAnalizeWdScripts()
        {
            var codeAnalizator2 = new SharpCodeAnalizator(CodeForAnalize.OrderItemFieldsCode, CodeGenerator.Enum.CodeLanguageEnum.Sharp, true);
            var propsForReplace = codeAnalizator2.Classes.FirstOrDefault()?.Props;

            // Проверяем существование директории
            string rootDir = $@"..\..\..\..\Projects\std\Std.WdScripts\Std.WdScripts.CalcScripts\";
            if (!Directory.Exists(rootDir))
            {
                throw new DirectoryNotFoundException($"Директория не найдена: {rootDir}");
            }

            // Получаем все поддиректории (папки проектов)
            string[] projectDirs = Directory.GetDirectories(rootDir);

            foreach (string projectDir in projectDirs)
            {
                ProjectProcessing(projectDir, propsForReplace);

            }

        }

        [TestMethod]
        public void TestAnalizeWdScripts2()
        {
            var codeAnalizator2 = new SharpCodeAnalizator(CodeForAnalize.OrderItemFieldsCode, CodeGenerator.Enum.CodeLanguageEnum.Sharp, true);
            var propsForReplace = codeAnalizator2.Classes.FirstOrDefault()?.Props;

            // Проверяем существование директории
            string projectDir = $@"..\..\..\..\Projects\std\Std.WdScripts\Std.WdScripts.CalcScripts\Расчет координат операций для алюминия\";

            ProjectProcessing(projectDir, propsForReplace);

        }

        private void ProjectProcessing(string projectDir, List<SharpClassProperty> propsForReplace)
        {
            string projectName = Path.GetFileName(projectDir);

            // Получаем все .cs файлы в папке проекта (без рекурсии)
            string[] classFiles = Directory.GetFiles(projectDir, "*.cs");
            var classNames = new List<string>();

            foreach (string file in classFiles.Where(f => f.Contains("Service.cs") || f.Contains("RunCalc.cs")))
            {
                string className = Path.GetFileNameWithoutExtension(file);
                if (!string.IsNullOrEmpty(className))
                {
                    classNames.Add(className);
                }

                string content = File.ReadAllText(file);
                var codeAnalizator = new SharpCodeAnalizator(content, CodeGenerator.Enum.CodeLanguageEnum.Sharp);

                var classForChange = codeAnalizator.Classes.Count > 1 ? codeAnalizator.Classes.FirstOrDefault(c => c.Name.Contains("Service")) : codeAnalizator.Classes.FirstOrDefault();
                if (classForChange.Name.Contains("RunCalc"))
                {
                    SharpClassMethods runMeth = classForChange.Methods.FirstOrDefault(m => m.Name == "Run");
                    SharpClassMethods runParallelMeth = null;
                    runParallelMeth = new SharpClassMethods("RunParallel", runMeth.Code);
                    runParallelMeth.Code = runParallelMeth.Code.Replace("Run(dbconn _db, DataRow dr", "RunParallel(dbconn _db, OrderitemRowForParallel dr");
                    runParallelMeth.Code = runParallelMeth.Code.Replace("RunService(", "RunServiceParallel(");

                    string newContent = content.Replace(runMeth.Code, runMeth.Code + Environment.NewLine + Environment.NewLine + runParallelMeth.Code);

                    newContent = newContent.Replace("using System;", "using System;" + Environment.NewLine + "using Atechnology.ecad.Document.DataSets;");
                    File.WriteAllText(file, newContent);
                }


                if (classForChange.Name.Contains("Service"))
                {
                    SharpClassMethods runMeth = classForChange.Methods.FirstOrDefault(m => m.Name == "RunService");
                    SharpClassMethods runParallelMeth = null;
                    runParallelMeth = new SharpClassMethods("RunServiceParallel", runMeth.Code);
                    runParallelMeth.Code = runParallelMeth.Code.Replace("RunService(dbconn _db, DataRow dr", "RunServiceParallel(dbconn _db, OrderitemRowForParallel dr");
                    runParallelMeth.Code = runParallelMeth.Code.Replace("RunService(dbconn _db,DataRow dr", "RunServiceParallel(dbconn _db, OrderitemRowForParallel dr");
                    runParallelMeth.Code = runParallelMeth.Code.Replace("using System;", "using System;" + Environment.NewLine + "using Atechnology.ecad.Document.DataSets;");
                    runParallelMeth.Code = runParallelMeth.Code.Replace("DataSet ds = dr.Table.DataSet;", "");
                    runParallelMeth.Code = runParallelMeth.Code.Replace("drOI=(ds_order.orderitemRow)dr;", "OrderitemRowForParallel drOI = dr;");
                    runParallelMeth.Code = runParallelMeth.Code.Replace("Order=dr.Table.DataSet.ExtendedProperties[\"DocClass\"] as OrderClass;", "Order = dr.Order;");
                    runParallelMeth.Code = runParallelMeth.Code.Replace("Order = dr.Table.DataSet.ExtendedProperties[\"DocClass\"] as OrderClass;", "Order = dr.Order;");
                    runParallelMeth.Code = runParallelMeth.Code.Replace("drOI,", "drOI.OrderItemRow,");
                    runParallelMeth.Code = runParallelMeth.Code.Replace("oiRow,", "oiRow.OrderItemRow,");
                    runParallelMeth.Code = runParallelMeth.Code.Replace("drOI.Table", "drOI.OrderItemRow.Table");

                    runParallelMeth.Code = runParallelMeth.Code.Replace("ds_order.orderitemRow oiRow = (ds_order.orderitemRow)dr;", "OrderitemRowForParallel oiRow = dr;");
                    //runParallelMeth.Code = runParallelMeth.Code.Replace("service.RunService", "service.RunServiceParallel");

                    foreach (var propForReplace in propsForReplace)
                    {
                        runParallelMeth.Code = runParallelMeth.Code.Replace("!oiRow.Is" + propForReplace.Name.ToLower() + "Null()", $"oiRow.{propForReplace.Name} != null");
                        runParallelMeth.Code = runParallelMeth.Code.Replace("!drOI.Is" + propForReplace.Name.ToLower() + "Null()", $"drOI.{propForReplace.Name} != null");
                        runParallelMeth.Code = runParallelMeth.Code.Replace("oiRow.Is" + propForReplace.Name.ToLower() + "Null()", $"oiRow.{propForReplace.Name} == null");
                        runParallelMeth.Code = runParallelMeth.Code.Replace("drOI.Is" + propForReplace.Name.ToLower() + "Null()", $"drOI.{propForReplace.Name} == null");
                        runParallelMeth.Code = runParallelMeth.Code.Replace($@"oiRow[""{propForReplace.Name.ToLower()}""]", $@"oiRow." + propForReplace.Name);
                        runParallelMeth.Code = runParallelMeth.Code.Replace($@"drOI[""{propForReplace.Name.ToLower()}""]", $@"drOI." + propForReplace.Name);

                    }

                    runParallelMeth.Code = runParallelMeth.Code.Replace("inRange(oiRow.Id", "inRange((int)oiRow.Id");
                    runParallelMeth.Code = runParallelMeth.Code.Replace("inRange( oiRow.Id", "inRange((int)oiRow.Id");
                    runParallelMeth.Code = runParallelMeth.Code.Replace("inRange(drOI.Id", "inRange((int)drOI.Id");
                    runParallelMeth.Code = runParallelMeth.Code.Replace("inRange( drOI.Id", "inRange((int)drOI.Id");

                    string newContent = content.Replace(runMeth.Code, runMeth.Code + Environment.NewLine + Environment.NewLine + runParallelMeth.Code);
                    File.WriteAllText(file, newContent);
                }

                //string res = string.Join(Environment.NewLine, propsForChange.Select(p => p.Code));
            }
        }
    }
}