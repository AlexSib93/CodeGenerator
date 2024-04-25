using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idcolorgroupprice", Name = "idx_goodpricehistory_idcolorgroupprice")]
    [Index("idgood", Name = "idx_goodpricehistory_idgood")]
    [Index("idpeople", Name = "idx_goodpricehistory_idpeople")]
    [Index("idvalut", Name = "idx_goodpricehistory_idvalut")]
    public partial class goodpricehistory
    {
        [Key]
        public int idgoodpricehistory { get; set; }
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
        [Column(TypeName = "datetime")]
        public DateTime? dt { get; set; }
        public int idpeople { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? planprice { get; set; }

        [ForeignKey("idcolorgroupprice")]
        [InverseProperty("goodpricehistory")]
        public virtual colorgroupprice idcolorgrouppriceNavigation { get; set; } = null!;
        [ForeignKey("idgood")]
        [InverseProperty("goodpricehistory")]
        public virtual good idgoodNavigation { get; set; } = null!;
        [ForeignKey("idpeople")]
        [InverseProperty("goodpricehistory")]
        public virtual people idpeopleNavigation { get; set; } = null!;
        [ForeignKey("idvalut")]
        [InverseProperty("goodpricehistory")]
        public virtual valut idvalutNavigation { get; set; } = null!;
    }
}
