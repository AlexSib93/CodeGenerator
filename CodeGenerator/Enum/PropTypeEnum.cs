namespace CodeGenerator.Enum
{
    public enum PropTypeEnum
    {
        /// <summary>
        /// Свойство примитивного типа
        /// </summary>
        Single = 0,
        /// <summary>
        /// Свойство ссылка на Матера (объект-родитель)
        /// </summary>
        Master = 1,
        /// <summary>
        /// Свойство детейлов
        /// </summary>
        Detail = 2,
        /// <summary>
        /// Свойство - значение выбираемое из справочника
        /// </summary>
        DictValue = 3,
        /// <summary>
        /// Свойство перечисления
        /// </summary>
        Enum = 4
    }
}