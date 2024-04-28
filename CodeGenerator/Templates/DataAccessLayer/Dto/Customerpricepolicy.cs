using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idcustomer", Name = "idx_customerpricepolicy_idcustomer")]
    [Index("idpricechange", Name = "idx_customerpricepolicy_idpricechange")]
    public partial class customerpricepolicy
    {
        [Key]
        public int idcustomerpricepolicy { get; set; }
        public int? idcustomer { get; set; }
        public int? idpricechange { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? creditlimit { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtexpiration { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price1 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price3 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price4 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price5 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price6 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price7 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price8 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price9 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price10 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price11 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price12 { get; set; }

        [ForeignKey("idcustomer")]
        [InverseProperty("customerpricepolicy")]
        public virtual customer? idcustomerNavigation { get; set; }
        [ForeignKey("idpricechange")]
        [InverseProperty("customerpricepolicy")]
        public virtual pricechange? idpricechangeNavigation { get; set; }
    }
}
