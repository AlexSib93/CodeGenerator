using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idorder", Name = "idx_orderpricechange_idorder")]
    [Index("idorderitem", Name = "idx_orderpricechange_idorderitem")]
    [Index("idpricechange", Name = "idx_orderpricechange_idpricechange")]
    [Index("idvalut", Name = "idx_orderpricechange_idvalut")]
    public partial class orderpricechange
    {
        [Key]
        public int idorderpricechange { get; set; }
        public int? idorder { get; set; }
        public int? idorderitem { get; set; }
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
        public int? idpeopleedit { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtedit { get; set; }

        [ForeignKey("idorder")]
        [InverseProperty("orderpricechange")]
        public virtual orders? idorderNavigation { get; set; }
        [ForeignKey("idpricechange")]
        [InverseProperty("orderpricechange")]
        public virtual pricechange? idpricechangeNavigation { get; set; }
        [ForeignKey("idvalut")]
        [InverseProperty("orderpricechange")]
        public virtual valut? idvalutNavigation { get; set; }
    }
}
