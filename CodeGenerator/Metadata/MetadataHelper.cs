using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Metadata
{
    public class MetadataHelper
    {
        public static FormMetadata GetFormMetadata(ModelMetadata mM) 
        {
            List<ComponentMetadata> components = new List<ComponentMetadata> { };
            foreach (var component in mM.Props)
            {
                if (component.IsPrimaryKey==false && component.IsVirtual==false)
                {
                    components.Add(new ComponentMetadata()
                    {
                        Name = component.Name,
                        Caption = component.Caption,
                        Type = component.Type == "DateTime" ? "DateTime" : "Input"
                    });
                }
            }
            if (components.Count>0)
                components.Add(new ComponentMetadata() { Type = "SubmitButton" });

            return new FormMetadata()
            {
                Name = mM.Name + "s",
                Caption = mM.Caption,
                Model = mM,
                AddToNavBar = true,
                Components = new ComponentMetadata[] {
                    new ComponentMetadata() { Name = mM.Name, Caption = mM.Caption, Type = "Table", Props = mM.Props }
                },
                EditForm = new FormMetadata()
                {
                    Name = mM.Name+ "EditForm",
                    Caption = mM.Caption,
                    Model = mM,
                    Components = components.ToArray(),
                }
            };
        }
    }
}
