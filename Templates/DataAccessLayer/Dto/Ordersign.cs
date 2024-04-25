using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idorder", Name = "idx_ordersign_idorder")]
    [Index("idpeople", Name = "idx_ordersign_idpeople")]
    [Index("idsign", Name = "idx_ordersign_idsign")]
    [Index("idsignvalue", Name = "idx_ordersign_idsignvalue")]
    public partial class ordersign
    {
        [Key]
        public int idordersign { get; set; }
        public int? idsign { get; set; }
        public int? idorder { get; set; }
        public int? idsignvalue { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcreate { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? idpeople { get; set; }
        [Unicode(false)]
        public string? strvalue { get; set; }
        [Column(TypeName = "numeric(15, 5)")]
        public decimal? intvalue { get; set; }
        public int? idorderitem { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtvalue { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtvalue2 { get; set; }
        public int? addint1 { get; set; }
        public int? addint2 { get; set; }
        public int? addint3 { get; set; }

        [ForeignKey("idorder")]
        [InverseProperty("ordersign")]
        public virtual orders? idorderNavigation { get; set; }
        [ForeignKey("idpeople")]
        [InverseProperty("ordersign")]
        public virtual people? idpeopleNavigation { get; set; }
        [ForeignKey("idsign")]
        [InverseProperty("ordersign")]
        public virtual sign? idsignNavigation { get; set; }
        [ForeignKey("idsignvalue")]
        [InverseProperty("ordersign")]
        public virtual signvalue? idsignvalueNavigation { get; set; }
    }
}
