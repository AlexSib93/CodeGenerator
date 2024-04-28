using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idfinparam", Name = "idx_finparamcalc_idfinparam")]
    [Index("idmodel", Name = "idx_finparamcalc_idmodel")]
    [Index("idorder", Name = "idx_finparamcalc_idorder")]
    [Index("idorderitem", Name = "ind_finparamcalc_idorderitem")]
    public partial class finparamcalc
    {
        [Key]
        public int idfinparamcalc { get; set; }
        public int? idfinparam { get; set; }
        public int? idmodel { get; set; }
        public int? idorder { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase { get; set; }
        public byte[]? smcrypt { get; set; }
        public byte[]? smbasecrypt { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase3 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase4 { get; set; }
        public int? idorderitem { get; set; }
        [Unicode(false)]
        public string? strvalue { get; set; }

        [ForeignKey("idfinparam")]
        [InverseProperty("finparamcalc")]
        public virtual finparam? idfinparamNavigation { get; set; }
        [ForeignKey("idmodel")]
        [InverseProperty("finparamcalc")]
        public virtual model? idmodelNavigation { get; set; }
        [ForeignKey("idorder")]
        [InverseProperty("finparamcalc")]
        public virtual orders? idorderNavigation { get; set; }
        [ForeignKey("idorderitem")]
        [InverseProperty("finparamcalc")]
        public virtual orderitem? idorderitemNavigation { get; set; }
    }
}
