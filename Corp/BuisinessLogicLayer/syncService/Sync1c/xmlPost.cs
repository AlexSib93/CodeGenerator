using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BuisinessLogicLayer.syncService.Sync1c
{
    public class xmlPost
    {
        public xmlPost() 
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        public Objects GetObjects()
        {
            Objects objects = new Objects
            {
                Items = new List<Object>
                {
                    new Object { Id = "1865", ObjectName = "Договор Серебристая 5, строение 1" },
                    new Object { Id = "1918", ObjectName = "Договор Спартаковская 3, подьезд 3" },
                    new Object { Id = "1955", ObjectName = "Договор Спартаковская 3, подьезд 3" },
                }
            };

            return objects;
        }

        public void GetString()
        {

            Objects objects = GetObjects();
            string serializedXML;
            var serializer = new XmlSerializer(typeof(Objects));

            using (var stringWriter = new StringWriter())
            {
                serializer.Serialize(stringWriter, objects);
                serializedXML = stringWriter.ToString();
            }

            Sync1cService sync1CService = new Sync1cService();

            sync1CService.Test(serializedXML);

        }

        public class Win1251StringWriter : StringWriter
        {
            public override Encoding Encoding => Encoding.GetEncoding(1251);
        }
    }
}

[XmlRoot("objects")]
public class Objects
{
    [XmlElement("object")]
    public List<Object> Items { get; set; } = new List<Object>();
}

public class Object
{
    [XmlAttribute("id")]
    public string Id { get; set; }

    [XmlAttribute("object_name")]
    public string ObjectName { get; set; }
}