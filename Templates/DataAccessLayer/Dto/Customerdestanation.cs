using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idcustomer", Name = "idx_customerdestanation_idcustomer")]
    [Index("iddestanation", Name = "idx_customerdestanation_iddestanation")]
    public partial class customerdestanation
    {
        [Key]
        public int idcustomerdestanation { get; set; }
        public int? idcustomer { get; set; }
        public int? iddestanation { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }

        [ForeignKey("idcustomer")]
        [InverseProperty("customerdestanation")]
        public virtual customer? idcustomerNavigation { get; set; }
        [ForeignKey("iddestanation")]
        [InverseProperty("customerdestanation")]
        public virtual destanation? iddestanationNavigation { get; set; }
    }
}
