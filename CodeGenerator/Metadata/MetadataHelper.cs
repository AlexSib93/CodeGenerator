using CodeGenerator.Enum;

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
                if (!propForComponent.IsPrimaryKey && !propForComponent.IsVirtual && propForComponent.PropType != PropTypeEnum.Enum)
                {
                    components.Add(new ComponentMetadata()
                    {
                        Name = propForComponent.Name,
                        Caption = propForComponent.Caption,
                        Type = propForComponent.TypeOfNullable == "DateTime"
                            ? ComponentTypeEnum.DateTime
                            : ((propForComponent.TypeOfNullable == "int" || propForComponent.TypeOfNullable == "decimal")
                                ? ComponentTypeEnum.NumericUpDown
                                : ((propForComponent.TypeOfNullable == "bool")
                                    ? ComponentTypeEnum.CheckBox
                                    : ComponentTypeEnum.Input))
                    });
                }

                if (propForComponent.PropType == PropTypeEnum.Detail)
                {
                    var type = propForComponent.TypeOfEnumerable;
                    var modelOfDetail = pM.Models.FirstOrDefault(m => m.Name == type);
                    if(modelOfDetail == null)
                    {
                        throw new Exception($"Модель, используемая в качестве типа для виртуального свойства не объявлена. Объявите модель с именем '{type}'");
                    }

                    List<PropMetadata> datailPropsMetadatas = modelOfDetail.Props.Where(x => !x.IsVirtual).ToList();
                    if (propForComponent.Name.ToLower() == "gpr")
                    {
                        datailPropsMetadatas.Add(new PropMetadata() { Name = "typeWork.name", Caption = "Наименование работ", Type = "string" });
                    }

                    if (propForComponent.Name == "Indicators")
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
                        Type = ComponentTypeEnum.Grid,
                        Props = datailPropsMetadatas,
                        ModelPropMetadata = propForComponent

                    });

                }

                if (propForComponent.PropType == PropTypeEnum.DictValue)
                {
                    var modelOfMaster = pM.Models.FirstOrDefault(m => m.Name == propForComponent.Type);
                    List<PropMetadata> props = modelOfMaster.Props.Where(x => !x.IsVirtual).ToList();
                    components.Add(new ComponentMetadata()
                    {
                        Name = propForComponent.Name,
                        Caption = propForComponent.Caption,
                        Type = ComponentTypeEnum.LookUp,
                        Props = new List<PropMetadata>() { new PropMetadata { Name = string.Join(" + ' ' + ",props.Where(p => !p.IsPrimaryKey).Select(p => "i." + StringHelper.ToLowerFirstChar(p.Name))) } },
                        ModelPropMetadata = propForComponent

                    });

                }

                if (propForComponent.PropType == PropTypeEnum.Enum)
                {
                    components.Add(new ComponentMetadata()
                    {
                        Name = propForComponent.Name,
                        Caption = propForComponent.Caption,
                        Type = ComponentTypeEnum.EnumLookUp,
                        ModelPropMetadata = propForComponent

                    });

                }

            }
            if (components.Count > 0)
            {
                components.Add(new ComponentMetadata() { Type = ComponentTypeEnum.CancelButton });
                components.Add(new ComponentMetadata() { Type = ComponentTypeEnum.SaveButton });
            }
            List <string> excludeNovBar = new List<string>() {
                "Agreement", "Indicator", "Gpr", "Kc", "Payment", "CharacteristicObj"
            };
            return new FormMetadata()
            {
                Name = mM.Name + "s",
                Caption = mM.Caption,
                Model = mM,
                AddToNavBar = !excludeNovBar.Contains(mM.Name),
                Components = new ComponentMetadata[]
                {
                    new ComponentMetadata()
                    {
                        Name = mM.Name,
                        Caption = mM.Caption,
                        Type = ComponentTypeEnum.Grid,
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
