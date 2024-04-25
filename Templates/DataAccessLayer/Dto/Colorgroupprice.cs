using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idcolorgroupcustom", Name = "idx_colorgroupprice_idcolorgroupcustom")]
    public partial class colorgroupprice
    {
        public colorgroupprice()
        {
            colorgrouppriceitem = new HashSet<colorgrouppriceitem>();
            goodcolorgroupprice = new HashSet<goodcolorgroupprice>();
            goodcolorparam = new HashSet<goodcolorparam>();
            goodpricehistory = new HashSet<goodpricehistory>();
        }

        [Key]
        public int idcolorgroupprice { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? idcolorgroupcustom { get; set; }
        public bool combine { get; set; }

        [ForeignKey("idcolorgroupcustom")]
        [InverseProperty("colorgroupprice")]
        public virtual colorgroupcustom? idcolorgroupcustomNavigation { get; set; }
        [InverseProperty("idcolorgrouppriceNavigation")]
        public virtual ICollection<colorgrouppriceitem> colorgrouppriceitem { get; set; }
        [InverseProperty("idcolorgrouppriceNavigation")]
        public virtual ICollection<goodcolorgroupprice> goodcolorgroupprice { get; set; }
        [InverseProperty("idcolorgrouppriceNavigation")]
        public virtual ICollection<goodcolorparam> goodcolorparam { get; set; }
        [InverseProperty("idcolorgrouppriceNavigation")]
        public virtual ICollection<goodpricehistory> goodpricehistory { get; set; }
    }
}
