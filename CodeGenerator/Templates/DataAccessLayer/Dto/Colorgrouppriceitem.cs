using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idcolor1", Name = "idx_colorgrouppriceitem_idcolor1")]
    [Index("idcolor2", Name = "idx_colorgrouppriceitem_idcolor2")]
    [Index("idcolorgroupprice", Name = "idx_colorgrouppriceitem_idcolorgroupprice")]
    public partial class colorgrouppriceitem
    {
        [Key]
        public int idcolorgrouppriceitem { get; set; }
        public int? idcolorgroupprice { get; set; }
        public int? idcolor1 { get; set; }
        public int? idcolor2 { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? code { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }

        [ForeignKey("idcolor1")]
        [InverseProperty("colorgrouppriceitemidcolor1Navigation")]
        public virtual color? idcolor1Navigation { get; set; }
        [ForeignKey("idcolor2")]
        [InverseProperty("colorgrouppriceitemidcolor2Navigation")]
        public virtual color? idcolor2Navigation { get; set; }
        [ForeignKey("idcolorgroupprice")]
        [InverseProperty("colorgrouppriceitem")]
        public virtual colorgroupprice? idcolorgrouppriceNavigation { get; set; }
    }
}
