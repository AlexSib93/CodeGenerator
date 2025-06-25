using CodeGenerator.Classes;
using CodeGenerator.Enum;
using CodeGenerator.Interfaces;
using CodeGenerator.Metadata;
using CodeGenerator.ProjectFiles.Cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Projects
{
    public class WinDrawScriptProject : Project, IProject
    {
        public SharpCodeAnalizator Analizator { get; set; }
        public WinDrawScriptProject(ProjectMetadata projectMetadata): base(projectMetadata)
        {
            TemplateProjectName = "WdScript";
            var wdServiceClass = Metadata.Models.FirstOrDefault();
            if(wdServiceClass != null)
            {                
                Analizator = new SharpCodeAnalizator(wdServiceClass.InitData, CodeLanguageEnum.Sharp);

                //Сначала RunCalc
                var classRunCalc = Analizator.Classes.FirstOrDefault(c => c.Name == "RunCalc");
                if (classRunCalc != null)
                {
                    Items.Add(new ProjectItem(this, new WinDrawServiceClass(wdServiceClass, projectMetadata, classRunCalc.Code) { Name = "RunCalc" }, wdServiceClass.Name, $"{Metadata.Path}\\{Name}", "cs"));
                }

                //Потом остальные

                foreach (SharpClass sharpClass in Analizator.Classes.Where(c => c.Name != "RunCalc"))
                {
                    Items.Add(new ProjectItem(this, new WinDrawServiceClass(new ModelMetadata() { Name = sharpClass.Name, InitData  = wdServiceClass.InitData}, projectMetadata, sharpClass.Code), sharpClass.Name, $"{Metadata.Path}\\{Name}", "cs"));
                }
            }

        }

    }
}
