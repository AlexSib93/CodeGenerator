using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idcustomer", Name = "idx_customersign_idcustomer")]
    [Index("idpeople", Name = "idx_customersign_idpeople")]
    [Index("idsign", Name = "idx_customersign_idsign")]
    public partial class customersign
    {
        [Key]
        public int idcustomersign { get; set; }
        public int? idcustomer { get; set; }
        public int? idsign { get; set; }
        public int? idsignvalue { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcreate { get; set; }
        public int? idpeople { get; set; }
        [Unicode(false)]
        public string? strvalue { get; set; }
        [Column(TypeName = "numeric(15, 5)")]
        public decimal? intvalue { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtvalue { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtvalue2 { get; set; }

        [ForeignKey("idcustomer")]
        [InverseProperty("customersign")]
        public virtual customer? idcustomerNavigation { get; set; }
        [ForeignKey("idpeople")]
        [InverseProperty("customersign")]
        public virtual people? idpeopleNavigation { get; set; }
        [ForeignKey("idsign")]
        [InverseProperty("customersign")]
        public virtual sign? idsignNavigation { get; set; }
    }
}
