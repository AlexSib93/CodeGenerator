using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idcustomer", Name = "idx_customerpricechangehistory_idcustomer")]
    [Index("idcustomerpricechange", Name = "idx_customerpricechangehistory_idcustomerpricechange")]
    [Index("idpeople", Name = "idx_customerpricechangehistory_idpeople")]
    [Index("idpricechange", Name = "idx_customerpricechangehistory_idpricechange")]
    [Index("idseller", Name = "idx_customerpricechangehistory_idseller")]
    public partial class customerpricechangehistory
    {
        [Key]
        public int idcustomerpricechangehistory { get; set; }
        public int? idcustomerpricechange { get; set; }
        public int? idcustomer { get; set; }
        public int? idpricechange { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price1 { get; set; }
        public int? idseller { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? idpeople { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dt { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? comment { get; set; }

        [ForeignKey("idcustomer")]
        [InverseProperty("customerpricechangehistory")]
        public virtual customer? idcustomerNavigation { get; set; }
        [ForeignKey("idcustomerpricechange")]
        [InverseProperty("customerpricechangehistory")]
        public virtual customerpricechange? idcustomerpricechangeNavigation { get; set; }
        [ForeignKey("idpeople")]
        [InverseProperty("customerpricechangehistory")]
        public virtual people? idpeopleNavigation { get; set; }
        [ForeignKey("idpricechange")]
        [InverseProperty("customerpricechangehistory")]
        public virtual pricechange? idpricechangeNavigation { get; set; }
        [ForeignKey("idseller")]
        [InverseProperty("customerpricechangehistory")]
        public virtual seller? idsellerNavigation { get; set; }
    }
}
