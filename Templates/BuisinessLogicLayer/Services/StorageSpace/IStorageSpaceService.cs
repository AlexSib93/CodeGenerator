using System.Collections.Generic;
using DataAccessLayer.Dto;

namespace BuisinessLogicLayer.Services
{
    public interface IStorageSpaceService
    {
        storagespace Create(storagespace storageSpace);
        storagespace Get(int id);
        storagespace Get(string barcode);
        storagespace SetParentNull(string barcode);
    }
}