using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using DataAccessLayer.Dto;
using Microsoft.EntityFrameworkCore;

namespace BuisinessLogicLayer.Services
{
    public class StorageSpaceService : BaseService, IStorageSpaceService
    {
        public StorageSpaceService(IGenUoW unit) : base(unit)
        {
        }

        public storagespace Create(storagespace storageSpace)
        {
            storageSpace.idstoragespace = Unit.RepStoragespace.GenId();
            Unit.RepStoragespace.Create(storageSpace);

            return storageSpace;
        }

        public storagespace Get(int id)
        {
            storagespace res = Unit.RepStoragespace.Get(ss => ss.idstoragespace == id,ss => ss.idparentNavigation, ss => ss.idstoredepartNavigation, ss => ss.idparentNavigation.idstoredepartNavigation);
            
            return res;
        }

        public storagespace Get(string barcode)
        {
            if (barcode.Length != 11)
                throw new Exception($"Баркод '{barcode}' не распознан. \nДлина баркода должна составлять 11 символов");

            string type = barcode.Substring(0, 4);
            string row = barcode.Substring(4, 3);
            string cell = barcode.Substring(7, 4);
            storagespace space = Unit.RepStoragespace.Set( )
                .Include( ss => ss.idparentNavigation)
                .Include(ss => ss.idparentNavigation.idstoredepartNavigation)
                .Include(ss => ss.idstoredepartNavigation)
                .FirstOrDefault(ss => ss.barcode == barcode && ss.deleted == null);
            if(space == null)
            {
                space = Unit.RepStoragespace.Set()
                .Include(ss => ss.idparentNavigation)
                .Include(ss => ss.idparentNavigation.idstoredepartNavigation)
                .Include(ss => ss.idstoredepartNavigation)
                    .FirstOrDefault(ss => ss.row == row && ss.cell == cell && ss.deleted == null);
            }

            return space;
        }

        public storagespace SetParentNull(string barcode)
        {
            storagespace ss = Get(barcode);
            ss.idparent = null;

            Unit.RepStoragespace.Update(ss);

            return ss;
        }
    }
}