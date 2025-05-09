﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Metadata
{
    public enum ComponentTypeEnum
    {
        /// <summary>
        /// Таблица детейлов
        /// </summary>
        DetailTable = 1,
        Input = 2,
        DateTime = 3,
        NumericUpDown = 4,
        CancelButton = 5,
        SubmitButton = 6,
        SaveButton = 7,
        LookUp = 8,
        Grid = 9,
        EnumLookUp = 10
    }
}
