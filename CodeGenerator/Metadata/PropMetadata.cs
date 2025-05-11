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
        public string? Type { get; set; }
        /// <summary>
        /// Отображаемое имя
        /// </summary>
        public string? Caption { get; set; }
        /// <summary>
        /// Первичный ключ, по умолчанию false, 
        /// </summary>
        public bool IsPrimaryKey { get; set; } = false;
        /// <summary>
        /// Свойство внешней связи
        /// </summary>
        public bool IsVirtual => 
            PropType == PropTypeEnum.DictValue 
            ||  PropType == PropTypeEnum.Detail
            ||  PropType == PropTypeEnum.DictValue
            ||  PropType == PropTypeEnum.Master;
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
        /// <summary>
        /// Выражение для вычислимого свойства
        /// </summary>
        public string? Expression { get; set; }
        /// <summary>
        /// Тип свойства
        /// </summary>
        public PropTypeEnum PropType { get; set; } = PropTypeEnum.Single;
        public bool IsEnumerable => Type!=null && ( Type.StartsWith("List") || Type.StartsWith("ICollection"));
        public bool IsNullable => Type.EndsWith("?");
        public string TypeOfEnumerable => IsEnumerable ? Type.Substring(Type.IndexOf("<") + 1, Type.IndexOf(">") - Type.IndexOf("<") - 1) : "";
        public string TypeOfNullable => Type.TrimEnd('?');

    }
}