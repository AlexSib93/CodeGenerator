using System;
using System.Collections.Generic;
using DataAccessLayer;
using DataAccessLayer.Dto;

namespace BuisinessLogicLayer.Services
{
    public class DelivDocService : BaseService, IDelivDocService
    {
        public DelivDocService(IGenUoW unit) : base(unit)
        {
        }

        public delivdoc Create(delivdoc delivdoc)
        {
            Unit.RepDelivDoc.Create(delivdoc);

            return delivdoc;
        }

        public delivdoc Get(int id)
        {
            delivdoc res = Unit.RepDelivDoc.Get(oi => oi.iddelivdoc == id, dd => dd.idcarNavigation);
            
            return res;
        }
    }
}