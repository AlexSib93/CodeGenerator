using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idcustomer", Name = "idx_pricelist_idcustomer")]
    [Index("iddocoper", Name = "idx_pricelist_iddocoper")]
    [Index("iddocstate", Name = "idx_pricelist_iddocstate")]
    [Index("idpeople", Name = "idx_pricelist_idpeople")]
    [Index("idpricelistgroup", Name = "idx_pricelist_idpricelistgroup")]
    [Index("idproductiontype", Name = "idx_pricelist_idproductiontype")]
    [Index("idseller", Name = "idx_pricelist_idseller")]
    [Index("idvalut", Name = "idx_pricelist_idvalut")]
    [Index("idversion", Name = "idx_pricelist_idversion")]
    [Index("idversion2", Name = "idx_pricelist_idversion2")]
    public partial class pricelist
    {
        public pricelist()
        {
            pricelistgoodservice = new HashSet<pricelistgoodservice>();
            pricelistitem = new HashSet<pricelistitem>();
            pricelistpricechange = new HashSet<pricelistpricechange>();
        }

        [Key]
        public int idpricelist { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? idpeople { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtdoc { get; set; }
        [Column(TypeName = "image")]
        public byte[]? picture { get; set; }
        public byte[]? classnative { get; set; }
        [Column("class")]
        public byte[]? _class { get; set; }
        public int? idversion { get; set; }
        public int? idpricelistgroup { get; set; }
        public int? iddocoper { get; set; }
        public int? idversion2 { get; set; }
        public int? idvalut { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? valutrate { get; set; }
        public int? idorderdocoper { get; set; }
        public short? modeltype { get; set; }
        public int? iddocstate { get; set; }
        public int? idproductiontype { get; set; }
        public int? idcustomer { get; set; }
        public int? idseller { get; set; }

        [ForeignKey("idcustomer")]
        [InverseProperty("pricelist")]
        public virtual customer? idcustomerNavigation { get; set; }
        [ForeignKey("iddocoper")]
        [InverseProperty("pricelist")]
        public virtual docoper? iddocoperNavigation { get; set; }
        [ForeignKey("iddocstate")]
        [InverseProperty("pricelist")]
        public virtual docstate? iddocstateNavigation { get; set; }
        [ForeignKey("idpeople")]
        [InverseProperty("pricelist")]
        public virtual people? idpeopleNavigation { get; set; }
        [ForeignKey("idpricelistgroup")]
        [InverseProperty("pricelist")]
        public virtual pricelistgroup? idpricelistgroupNavigation { get; set; }
        [ForeignKey("idproductiontype")]
        [InverseProperty("pricelist")]
        public virtual productiontype? idproductiontypeNavigation { get; set; }
        [ForeignKey("idseller")]
        [InverseProperty("pricelist")]
        public virtual seller? idsellerNavigation { get; set; }
        [ForeignKey("idversion")]
        [InverseProperty("pricelist")]
        public virtual versions? idversionNavigation { get; set; }
        [InverseProperty("idpricelistNavigation")]
        public virtual ICollection<pricelistgoodservice> pricelistgoodservice { get; set; }
        [InverseProperty("idpricelistNavigation")]
        public virtual ICollection<pricelistitem> pricelistitem { get; set; }
        [InverseProperty("idpricelistNavigation")]
        public virtual ICollection<pricelistpricechange> pricelistpricechange { get; set; }
    }
}
