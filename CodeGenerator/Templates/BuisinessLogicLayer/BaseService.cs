using DataAccessLayer;
using DataAccessLayer.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuisinessLogicLayer
{
    public abstract class BaseService
    {
        private IUnitOfWork unit;

        protected IUnitOfWork Unit { get; }

        protected BaseService(IUnitOfWork unit)
        {
            Unit = unit;
        }

    }
}

