using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("iddiscard", Name = "idx_orderdiscard_iddiscard")]
    [Index("idorder", Name = "idx_orderdiscard_idorder")]
    public partial class orderdiscard
    {
        [Key]
        public int idorderdiscard { get; set; }
        public int? idorder { get; set; }
        public int? iddiscard { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcreate { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? agreename { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? agreedate { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? qu { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? qu2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm2 { get; set; }

        [ForeignKey("iddiscard")]
        [InverseProperty("orderdiscard")]
        public virtual discard? iddiscardNavigation { get; set; }
        [ForeignKey("idorder")]
        [InverseProperty("orderdiscard")]
        public virtual orders? idorderNavigation { get; set; }
    }
}
