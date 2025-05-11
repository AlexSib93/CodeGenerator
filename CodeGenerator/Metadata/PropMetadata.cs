using CodeGenerator.Enum;

namespace CodeGenerator
{
    public class PropMetadata
    { 
        /// <summary>
        /// Наименование свойства
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Типы данных как в C#
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Отображаемое имя
        /// </summary>
        public string Caption { get; set; }
        /// <summary>
        /// Первичный ключ, по умолчанию false, 
        /// </summary>
        public bool IsPrimaryKey { get; set; } = false;
        /// <summary>
        /// Свойство внешней связи
        /// </summary>
        public bool IsVirtual => PropType != PropTypeEnum.Single;// && PropType != PropTypeEnum.EnumValue;
        /// <summary>
        /// Отображать свойство в интерфейсе
        /// </summary>
        public bool Visible { get; set; } = true;
        /// <summary>
        /// Доступ к редактированию поля
        /// </summary>
        public bool Editable { get; set; } = true;
        /// <summary>
        /// Не передавать на клиент
        /// </summary>
        public bool JsonIgnore { get; set; } = false;
        public bool IsEnumerable => Type!=null && ( Type.StartsWith("List") || Type.StartsWith("ICollection"));
        public bool IsNullable => Type.EndsWith("?");
        public string TypeOfEnumerable => IsEnumerable ? Type.Substring(Type.IndexOf("<") + 1, Type.IndexOf(">") - Type.IndexOf("<") - 1) : "";
        public string TypeOfNullable => Type.TrimEnd('?');

        public PropTypeEnum PropType { get; set; } = PropTypeEnum.Single;
    }
}