using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    public partial class customerrelation
    {
        [Key]
        public int idcustomerrelation { get; set; }
        public int? idparent { get; set; }
        public int? idchild { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtrel { get; set; }
        public Guid guid { get; set; }
    }
}
