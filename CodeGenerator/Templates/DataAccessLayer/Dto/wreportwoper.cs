using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    public partial class wreportwoper
    {
        [Key]
        public int idcwo { get; set; }
        public int idwork { get; set; }
        public int idworkoper { get; set; }
    }
}
