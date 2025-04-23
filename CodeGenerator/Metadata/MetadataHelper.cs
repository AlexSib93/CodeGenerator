using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Metadata
{
    public class MetadataHelper
    {
        public static List<FormMetadata> AutoCreateFormMetadata(ProjectMetadata pM)
        {
            List<FormMetadata> res = new List<FormMetadata>();
            foreach (ModelMetadata mM in pM.Models)
            {
                res.Add(AutoCreateFormMetadata(pM, mM));
            }

            return res;
        }

        public static FormMetadata AutoCreateFormMetadata(ProjectMetadata pM, ModelMetadata mM)
        {
            List<ComponentMetadata> components = new List<ComponentMetadata> { };
            foreach (var propForComponent in mM.Props)
            {
                if (!propForComponent.IsPrimaryKey && !propForComponent.IsVirtual)
                {
                    components.Add(new ComponentMetadata()
                    {
                        Name = propForComponent.Name,
                        Caption = propForComponent.Caption,
                        Type = propForComponent.Type == "DateTime"
                            ? "DateTime"
                            : ((propForComponent.Type == "int" || propForComponent.Type == "decimal")
                                ? "NumericUpDown"
                                : "Input")
                    });
                }

                if (propForComponent.IsDetailsProp)
                {
                    var type = propForComponent.TypeOfEnumerable;
                    var modelOfDetail = pM.Models.FirstOrDefault(m => m.Name == type);
                    List<PropMetadata> datailPropsMetadatas = modelOfDetail.Props.Where(x => !x.IsVirtual).ToList();
                    if (propForComponent.Name.ToLower() == "gpr")
                    {
                        components.Add(new ComponentMetadata() { Name = "typeWork.name", Caption = "Наименование работ", Type = "string" });
                    }

                    if (propForComponent.Name== "Indicators")
                    {
                        datailPropsMetadatas.Add(new PropMetadata() { Name = "nameIndicator.name", Caption="Показатель", Type = "string" });
                    }
                    //components.Add(new ComponentMetadata()
                    //{
                    //    Name = propForComponent.Name,
                    //    Caption = propForComponent.Caption,
                    //    Type = ComponentTypeEnum.DetailTable.ToString(),
                    //    Props = datailPropsMetadatas,
                    //    ModelPropMetadata = propForComponent

                    //});                    
                    components.Add(new ComponentMetadata()
                    {
                        Name = propForComponent.Name,
                        Caption = propForComponent.Caption,
                        Type = ComponentTypeEnum.Grid.ToString(),
                        Props = datailPropsMetadatas,
                        ModelPropMetadata = propForComponent

                    });

                }

                if (propForComponent.IsDictValueProp)
                {
                    var modelOfMaster = pM.Models.FirstOrDefault(m => m.Name == propForComponent.Type);
                    List<PropMetadata> props = modelOfMaster.Props.Where(x => !x.IsVirtual).ToList();
                    components.Add(new ComponentMetadata()
                    {
                        Name = propForComponent.Name,
                        Caption = propForComponent.Caption,
                        Type = ComponentTypeEnum.LookUp.ToString(),
                        Props = new List<PropMetadata>() { new PropMetadata { Name = string.Join(" + ' ' + ",props.Select(p => "i." + StringHelper.ToLowerFirstChar(p.Name))) } },
                        ModelPropMetadata = propForComponent

                    });

                }

            }
            if (components.Count > 0)
            {
                components.Add(new ComponentMetadata() { Type = ComponentTypeEnum.CancelButton.ToString() });
                components.Add(new ComponentMetadata() { Type = ComponentTypeEnum.SubmitButton.ToString() });
            }
            List <string> excludeNovBar = new List<string>() {
                "Agreement", "Indicator", "GPR", "KC", "Payment"
            };
            return new FormMetadata()
            {
                Name = mM.Name + "s",
                Caption = mM.Caption,
                Model = mM,
                AddToNavBar = !excludeNovBar.Contains(mM.Name),
                Components = new ComponentMetadata[]
                {
                    //new ComponentMetadata()
                    //{
                    //    Name = mM.Name,
                    //    Caption = mM.Caption,
                    //    Type = "Table",
                    //    Props = mM.Props.Where(x => !x.IsVirtual).ToList()
                    //},
                    new ComponentMetadata()
                    {
                        Name = mM.Name,
                        Caption = mM.Caption,
                        Type = ComponentTypeEnum.Grid.ToString(),
                        Props = mM.Props.Where(x => !x.IsVirtual).ToList()
                    }
                },
                EditForm = new FormMetadata()
                {
                    Name = mM.Name + "EditForm",
                    Caption = mM.Caption,
                    Model = mM,
                    Components = components.ToArray(),
                }
            };
        }

    }
}
