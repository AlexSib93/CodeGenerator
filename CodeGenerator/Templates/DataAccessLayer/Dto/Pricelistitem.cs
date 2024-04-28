using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idpricelist", Name = "idx_pricelistitem_idpricelist")]
    [Index("width", Name = "idx_pricelistitem_width")]
    public partial class pricelistitem
    {
        public pricelistitem()
        {
            pricelistgoodservice = new HashSet<pricelistgoodservice>();
        }

        [Key]
        public int idpricelistitem { get; set; }
        public int? idpricelist { get; set; }
        public int? height { get; set; }
        public int? width { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price1 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price2 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }

        [ForeignKey("idpricelist")]
        [InverseProperty("pricelistitem")]
        public virtual pricelist? idpricelistNavigation { get; set; }
        [InverseProperty("idpricelistitemNavigation")]
        public virtual ICollection<pricelistgoodservice> pricelistgoodservice { get; set; }
    }
}
