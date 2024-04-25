
using BuisinessLogicLayer.Enum;
using BuisinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisinessLogicLayer.Services.Domain
{
    public class BarcodeService
    {
        public static BarcodeInfo GetBarcodeInfo(string barcode)
        {
            if (barcode.Length != 11)
                throw new Exception($"Баркод '{barcode}' не распознан. \nДлина баркода должна составлять 11 символов");

            var info = new BarcodeInfo();
            if (barcode.StartsWith("7777"))
            {
                info.Type = BarcodeTypeEnum.StorageSpace;
                info.Id = int.Parse(barcode.Substring(4));
            }
            else if (System.Enum.TryParse(barcode.Substring(0, 1), out BarcodeTypeEnum type))
            {
                info.Type = type;
                info.Id = int.Parse(barcode.Substring(1));
            }
            else
                throw new Exception("Не удалось определить тип баркода");

            return info;
        }

        public static string GenBarcodeById(BarcodeTypeEnum barcodeType, int id)
        {
            return ((int)barcodeType).ToString("D1") + id.ToString("D10");
        }

    }
}
