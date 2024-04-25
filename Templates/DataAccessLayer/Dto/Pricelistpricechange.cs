using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idpricechange", Name = "idx_pricelistpricechange_idpricechange")]
    [Index("idpricelist", Name = "idx_pricelistpricechange_idpricelist")]
    [Index("idvalut", Name = "idx_pricelistpricechange_idvalut")]
    public partial class pricelistpricechange
    {
        [Key]
        public int idpricelistpricechange { get; set; }
        public int? idpricelist { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? perc { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase { get; set; }
        public int? idvalut { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? valutrate { get; set; }
        public int? idpricechange { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }

        [ForeignKey("idpricechange")]
        [InverseProperty("pricelistpricechange")]
        public virtual pricechange? idpricechangeNavigation { get; set; }
        [ForeignKey("idpricelist")]
        [InverseProperty("pricelistpricechange")]
        public virtual pricelist? idpricelistNavigation { get; set; }
        [ForeignKey("idvalut")]
        [InverseProperty("pricelistpricechange")]
        public virtual valut? idvalutNavigation { get; set; }
    }
}
