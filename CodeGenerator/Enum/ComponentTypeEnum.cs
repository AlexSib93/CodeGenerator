using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Enum
{
    /// <summary>
    /// Тип компонента формы
    /// </summary>
    public enum ComponentTypeEnum
    {
        /// <summary>
        /// Таблица детейлов
        /// </summary>
        DetailTable = 1,
        /// <summary>
        /// Текстовое поле ввода
        /// </summary>
        Input = 2,
        /// <summary>
        /// Поле выбора даты
        /// </summary>
        DateTime = 3,
        /// <summary>
        /// Поле ввода числа
        /// </summary>
        NumericUpDown = 4,
        /// <summary>
        /// Кнопка отмены
        /// </summary>
        CancelButton = 5,
        /// <summary>
        /// Кнопка отправки формы
        /// </summary>
        SubmitButton = 6,
        /// <summary>
        /// Кнопка сохранения
        /// </summary>
        SaveButton = 7,
        /// <summary>
        /// Выпадающий список для выбора из справочника
        /// </summary>
        LookUp = 8,
        /// <summary>
        /// Таблица с фильтрами и сортировкой
        /// </summary>
        Grid = 9,
        /// <summary>
        /// Выпадающий список для выбора из типа-перечисления
        /// </summary>
        EnumLookUp = 10,
        /// <summary>
        /// Галочка
        /// </summary>
        CheckBox = 11,
        /// <summary>
        /// Кнопка "Добавить"
        /// </summary>
        AddButton = 12,
        /// <summary>
        /// Таблица
        /// </summary>
        Table = 13
    }
}
