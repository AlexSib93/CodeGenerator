using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idmodel", Name = "idx_ordersetting_idmodel")]
    [Index("idorder", Name = "idx_ordersetting_idorder")]
    [Index("idsetting", Name = "idx_ordersetting_idsetting")]
    public partial class ordersetting
    {
        [Key]
        public int idordersetting { get; set; }
        public int? idorder { get; set; }
        public int? idmodel { get; set; }
        public int? idsetting { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [Column(TypeName = "numeric(15, 6)")]
        public decimal? intvalue { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? strvalue { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "text")]
        public string? txtvalue { get; set; }
        public byte[]? blbvalue { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? groupname { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtvalue { get; set; }

        [ForeignKey("idmodel")]
        [InverseProperty("ordersetting")]
        public virtual model? idmodelNavigation { get; set; }
        [ForeignKey("idorder")]
        [InverseProperty("ordersetting")]
        public virtual orders? idorderNavigation { get; set; }
        [ForeignKey("idsetting")]
        [InverseProperty("ordersetting")]
        public virtual setting? idsettingNavigation { get; set; }
    }
}
