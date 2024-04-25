using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idcustomer", Name = "idx_destanationcustomer_idcustomer")]
    [Index("iddestanation", Name = "idx_destanationcustomer_iddestanation")]
    public partial class destanationcustomer
    {
        [Key]
        public int iddestanationcustomer { get; set; }
        public int? iddestanation { get; set; }
        public int? idcustomer { get; set; }
        public short? numpos { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }

        [ForeignKey("idcustomer")]
        [InverseProperty("destanationcustomer")]
        public virtual customer? idcustomerNavigation { get; set; }
        [ForeignKey("iddestanation")]
        [InverseProperty("destanationcustomer")]
        public virtual destanation? iddestanationNavigation { get; set; }
    }
}
