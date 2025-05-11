namespace CodeGenerator.Enum
{
    /// <summary>
    /// Тип хранилища данных (Релизация IUnitOfWork)
    /// </summary>
    public enum UnitOfWorkEnum
    {
        /// <summary>
        /// Хранилище в оперативной памяти Хоста
        /// </summary>
        MockUnit = 0,
        /// <summary>
        /// База данных с доступом через Entity FrameWork Core
        /// </summary>
        EfUnit = 1
    }
}