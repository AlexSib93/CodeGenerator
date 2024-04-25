using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisinessLogicLayer.Enum
{
    public enum DocStateEnum
    {
        /// <summary>
        /// На складе производства
        /// </summary>
        OnGpStorage = 17,
        /// <summary>
        /// Отгружен со склада производства
        /// </summary>
        LeftGpStorage = 16,
        /// <summary>
        /// На уд. складе
        /// </summary>
        OnRemoteStorage = 18,
        /// <summary>
        /// Отгружен с уд. склада
        /// </summary>
        LeftRemoteStorage = 19
    }
}
