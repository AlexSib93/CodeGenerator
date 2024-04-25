using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idcustomer", Name = "idx_customerclaim_idcustomer")]
    public partial class customerclaim
    {
        [Key]
        public int idcustomerclaim { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? orderdate { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? ordername { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? claimdate { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? idcustomer { get; set; }
        public Guid guid { get; set; }

        [ForeignKey("idcustomer")]
        [InverseProperty("customerclaim")]
        public virtual customer? idcustomerNavigation { get; set; }
    }
}
