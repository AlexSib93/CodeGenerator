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
                    components.Add(new ComponentMetadata()
                    {
                        Name = propForComponent.Name,
                        Caption = propForComponent.Caption,
                        Type = ComponentTypeEnum.DetailTable.ToString(),
                        Props = modelOfDetail.Props.Where(x => !x.IsVirtual).ToList(),
                        ModelPropMetadata = propForComponent

                    });

                }

                if (propForComponent.IsDictValueProp)
                {
                    var modelOfMaster = pM.Models.FirstOrDefault(m => m.Name == propForComponent.Type);
                    components.Add(new ComponentMetadata()
                    {
                        Name = propForComponent.Name,
                        Caption = propForComponent.Caption,
                        Type = ComponentTypeEnum.LookUp.ToString(),
                        Props = new List<PropMetadata>() { modelOfMaster.Props.FirstOrDefault(x => !x.IsVirtual) },
                        ModelPropMetadata = propForComponent

                    });

                }

            }
            if (components.Count > 0)
            {
                components.Add(new ComponentMetadata() { Type = ComponentTypeEnum.CancelButton.ToString() });
                components.Add(new ComponentMetadata() { Type = ComponentTypeEnum.SubmitButton.ToString() });
            }

            return new FormMetadata()
            {
                Name = mM.Name + "s",
                Caption = mM.Caption,
                Model = mM,
                AddToNavBar = true,
                Components = new ComponentMetadata[]
                {
                    new ComponentMetadata()
                    {
                        Name = mM.Name,
                        Caption = mM.Caption,
                        Type = "Table",
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
