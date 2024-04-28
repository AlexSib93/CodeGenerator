using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idcolor1", Name = "idx_goodcolorparam_idcolor1")]
    [Index("idcolor2", Name = "idx_goodcolorparam_idcolor2")]
    [Index("idcolorgroupprice", Name = "idx_goodcolorparam_idcolorgroupprice")]
    [Index("idgood", Name = "idx_goodcolorparam_idgood")]
    [Index("idgoodoptim", Name = "idx_goodcolorparam_idgoodoptim")]
    [Index("idstoragespace", Name = "idx_goodcolorparam_idstoragespace")]
    [Index("idstoredepart", Name = "idx_goodcolorparam_idstoredepart")]
    public partial class goodcolorparam
    {
        [Key]
        public int idgoodcolorparam { get; set; }
        public int idgood { get; set; }
        public int? idcolor1 { get; set; }
        public int? idcolor2 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? minost { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? waste { get; set; }
        public short? deliverytime { get; set; }
        public bool? usehouse { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? maxost { get; set; }
        public int? idcustomer { get; set; }
        [Column(TypeName = "numeric(8, 4)")]
        public decimal? rate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtpost { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? minost2 { get; set; }
        public bool replenishment { get; set; }
        public int? idgoodoptim { get; set; }
        public int? idstoragespace { get; set; }
        public int? idstoredepart { get; set; }
        public int? idcolorgroupprice { get; set; }
        public short? purchase { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? rank1 { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? rank2 { get; set; }

        [ForeignKey("idcolor1")]
        [InverseProperty("goodcolorparamidcolor1Navigation")]
        public virtual color? idcolor1Navigation { get; set; }
        [ForeignKey("idcolor2")]
        [InverseProperty("goodcolorparamidcolor2Navigation")]
        public virtual color? idcolor2Navigation { get; set; }
        [ForeignKey("idcolorgroupprice")]
        [InverseProperty("goodcolorparam")]
        public virtual colorgroupprice? idcolorgrouppriceNavigation { get; set; }
        [ForeignKey("idgood")]
        [InverseProperty("goodcolorparam")]
        public virtual good idgoodNavigation { get; set; } = null!;
        [ForeignKey("idgoodoptim")]
        [InverseProperty("goodcolorparam")]
        public virtual goodoptim? idgoodoptimNavigation { get; set; }
        [ForeignKey("idstoragespace")]
        [InverseProperty("goodcolorparam")]
        public virtual storagespace? idstoragespaceNavigation { get; set; }
        [ForeignKey("idstoredepart")]
        [InverseProperty("goodcolorparam")]
        public virtual storedepart? idstoredepartNavigation { get; set; }
    }
}
