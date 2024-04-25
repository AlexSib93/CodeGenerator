using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idcolorgroupprice", Name = "idx_goodcolorgroupprice_idcolorgroupprice")]
    [Index("idgood", Name = "idx_goodcolorgroupprice_idgood")]
    [Index("idgoodpricegroup", Name = "idx_goodcolorgroupprice_idgoodpricegroup")]
    [Index("idvalut", Name = "idx_goodcolorgroupprice_idvalut")]
    [Index("idvalut2", Name = "idx_goodcolorgroupprice_idvalut2")]
    public partial class goodcolorgroupprice
    {
        [Key]
        public int idgoodcolorgroupprice { get; set; }
        public int idcolorgroupprice { get; set; }
        public int idvalut { get; set; }
        public int idgood { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? k1 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? k2 { get; set; }
        public int? idgoodpricegroup { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? planprice { get; set; }
        public int? idvalut2 { get; set; }

        [ForeignKey("idcolorgroupprice")]
        [InverseProperty("goodcolorgroupprice")]
        public virtual colorgroupprice idcolorgrouppriceNavigation { get; set; } = null!;
        [ForeignKey("idgood")]
        [InverseProperty("goodcolorgroupprice")]
        public virtual good idgoodNavigation { get; set; } = null!;
        [ForeignKey("idgoodpricegroup")]
        [InverseProperty("goodcolorgroupprice")]
        public virtual goodpricegroup? idgoodpricegroupNavigation { get; set; }
        [ForeignKey("idvalut2")]
        [InverseProperty("goodcolorgrouppriceidvalut2Navigation")]
        public virtual valut? idvalut2Navigation { get; set; }
        [ForeignKey("idvalut")]
        [InverseProperty("goodcolorgrouppriceidvalutNavigation")]
        public virtual valut idvalutNavigation { get; set; } = null!;
    }
}
