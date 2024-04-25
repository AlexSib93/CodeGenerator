using DataAccessLayer;
using DataAccessLayer.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuisinessLogicLayer
{
    public abstract class BaseService
    {
        private IGenUoW unit;

        protected IGenUoW Unit { get; }

        protected BaseService(IGenUoW unit)
        {
            Unit = unit;
        }

    }
}

