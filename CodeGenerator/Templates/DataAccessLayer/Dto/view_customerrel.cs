using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_customerrel
    {
        public int idcustomerrel { get; set; }
        public int idcustomerparent { get; set; }
        public int idcustomerchild { get; set; }
        public int typ { get; set; }
        public int idcustomertyperel { get; set; }
    }
}
