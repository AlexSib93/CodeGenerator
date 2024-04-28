using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__goodpricegroup__5087998D", IsUnique = true)]
    public partial class goodpricegroup
    {
        public goodpricegroup()
        {
            good = new HashSet<good>();
            goodcolorgroupprice = new HashSet<goodcolorgroupprice>();
        }

        [Key]
        public int idgoodpricegroup { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price1 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price1toprice2 { get; set; }
        public Guid guid { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price_goodcolorgroupprice { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? k1_goodcolorgroupprice { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? k2_goodcolorgroupprice { get; set; }

        [InverseProperty("idgoodpricegroupNavigation")]
        public virtual ICollection<good> good { get; set; }
        [InverseProperty("idgoodpricegroupNavigation")]
        public virtual ICollection<goodcolorgroupprice> goodcolorgroupprice { get; set; }
    }
}
