using BuisinessLogicLayer.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisinessLogicLayer.Models
{
    public class BarcodeInfo
    {
        public int Id { get; set; }
        public BarcodeTypeEnum Type { get; set; } = BarcodeTypeEnum.Unknown;
    }
}
