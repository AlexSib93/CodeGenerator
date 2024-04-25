using BuisinessLogicLayer.Models;
using BuisinessLogicLayer.ViewModels;
using DataAccessLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisinessLogicLayer.Services
{
    public interface IRotoxHouseService
    {
        int IdPeople { get; set; }
        rotoxhouse Create(rotoxhouse rotoxHouse);
        List<rotoxhouse> Create(List<rotoxhouse> rotoxHouses);
        rotoxhouse Get(int id);
        List<RotoxHouse> GetByManufactDoc(int id);
        List<RotoxHouse> GetByDelivDoc(int id);
        List<RotoxHouse> GetByStorageSpace(string barcode, bool isSgp = true);
        RotoxHouse Scan(string barcode, bool isSgp = true);
        List<rotoxhouse> ScanCell(string barcode, List<rotoxhouse> items);
        List<rotoxhouse> ScanCellRemoteStore(string barcode, List<rotoxhouse> items);
        storagespace ScanFromCellToCell(string barcodefrom, string barcode);
        storagespace ScanFromCellToCellRemoteStore(string barcodefrom, string barcode);
        void ClearCell(string barcodefrom);
        void ClearItems(IEnumerable<int> idRotoxhouses);
        void Delete(rotoxhouse rh);
        RotoxHouse ShipItem(string barcode, int idDelivDoc);
        List<RotoxHouse> GetByOrder(int id);
    }
}
