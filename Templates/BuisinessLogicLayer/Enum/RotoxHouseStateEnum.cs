using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisinessLogicLayer.Enum
{
    public enum RotoxHouseStateEnum
    {
        /// <summary>
        /// Резерв
        /// </summary>
        Reserv = 0,
        /// <summary>
        /// Занято
        /// </summary>
        CellAssigned = 1,
        /// <summary>
        /// Комплектация
        /// </summary>
        Complectation = 2,
        /// <summary>
        /// Отгружено
        /// </summary>
        Left = 3
    }
}
