using CodeGenerator.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Metadata
{
    public class ComponentMetadata
    {
        /// <summary>
        /// Имя компонента. Для свойств модели - совпадает с именем свойства
        /// </summary>
        public string Name { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public ComponentTypeEnum Type { get; set; }
        public bool ModelProp { get; set; } = true;
        /// <summary>
        /// Свойство Модели для которого используется компонент
        /// </summary>
        public PropMetadata ModelPropMetadata { get; set; }
        /// <summary>
        /// Используется для табличных компонентов для передачи списка свойств и их подписей
        /// </summary>
        public List<PropMetadata> Props { get; set; } = new List<PropMetadata>();
    }
}
