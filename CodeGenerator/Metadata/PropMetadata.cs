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
        /// Имя столбца внешней связи
        /// </summary>
        public bool IsVirtual { get; set; }
    }
}