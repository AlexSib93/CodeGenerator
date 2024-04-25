using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idpricechange", Name = "idx_sellerpricechange_idpricechange")]
    [Index("idseller", Name = "idx_sellerpricechange_idseller")]
    public partial class sellerpricechange
    {
        [Key]
        public int idsellerpricechange { get; set; }
        public int idseller { get; set; }
        public int idpricechange { get; set; }
        [Column(TypeName = "numeric(18, 4)")]
        public decimal? price1 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public Guid guid { get; set; }
        public byte[]? price1crypt { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? startdate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? enddate { get; set; }

        [ForeignKey("idpricechange")]
        [InverseProperty("sellerpricechange")]
        public virtual pricechange idpricechangeNavigation { get; set; } = null!;
        [ForeignKey("idseller")]
        [InverseProperty("sellerpricechange")]
        public virtual seller idsellerNavigation { get; set; } = null!;
    }
}
