using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idgoodservice", Name = "idx_pricelistgoodservice_idgoodservice")]
    [Index("idpricelist", Name = "idx_pricelistgoodservice_idpricelist")]
    [Index("idpricelistitem", Name = "idx_pricelistgoodservice_idpricelistitem")]
    public partial class pricelistgoodservice
    {
        [Key]
        public int idpricelistgoodservice { get; set; }
        public int? idpricelist { get; set; }
        public int? idgoodservice { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? perc { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase { get; set; }
        public int? idvalut { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? valutrate { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? qu { get; set; }
        public int? idpricelistitem { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price2 { get; set; }
        public short? iscalc { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm2 { get; set; }

        [ForeignKey("idgoodservice")]
        [InverseProperty("pricelistgoodservice")]
        public virtual goodservice? idgoodserviceNavigation { get; set; }
        [ForeignKey("idpricelist")]
        [InverseProperty("pricelistgoodservice")]
        public virtual pricelist? idpricelistNavigation { get; set; }
        [ForeignKey("idpricelistitem")]
        [InverseProperty("pricelistgoodservice")]
        public virtual pricelistitem? idpricelistitemNavigation { get; set; }
    }
}
