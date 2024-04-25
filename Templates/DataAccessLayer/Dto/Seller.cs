using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__seller__13498123", IsUnique = true)]
    [Index("idaddclassification1", Name = "idx_seller_idaddclassification1")]
    [Index("idaddclassification2", Name = "idx_seller_idaddclassification2")]
    [Index("idaddclassification3", Name = "idx_seller_idaddclassification3")]
    [Index("idaddclassification4", Name = "idx_seller_idaddclassification4")]
    [Index("idaddclassification5", Name = "idx_seller_idaddclassification5")]
    [Index("idsellergroup", Name = "idx_seller_idsellergroup")]
    public partial class seller
    {
        public seller()
        {
            agreement = new HashSet<agreement>();
            customer = new HashSet<customer>();
            customerpricechange = new HashSet<customerpricechange>();
            customerpricechangehistory = new HashSet<customerpricechangehistory>();
            destanationseller = new HashSet<destanationseller>();
            orders = new HashSet<orders>();
            paymentdoc = new HashSet<paymentdoc>();
            pricelist = new HashSet<pricelist>();
            sellerdestanation = new HashSet<sellerdestanation>();
            sellerpricechange = new HashSet<sellerpricechange>();
            storedoc = new HashSet<storedoc>();
            supplydoc = new HashSet<supplydoc>();
        }

        [Key]
        public int idseller { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? sellercode { get; set; }
        public int? idsellergroup { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? discount { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? discount2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? discount3 { get; set; }
        public Guid guid { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? inn { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? kaccount { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? contactpeople { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? phone { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? address { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? bik { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? account { get; set; }
        public int? idaddress { get; set; }
        public int? idcustomer { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? okonh { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? okpo { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? bank { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addint { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addint2 { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? addstr { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? email { get; set; }
        [Column(TypeName = "image")]
        public byte[]? picture { get; set; }
        public int? iddestanation { get; set; }
        public int? idpeople { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? agreename { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? agreedate { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? name2 { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? addresslegal { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? phonemobile { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? directorfio { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? directorfounding { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? addstr1 { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? addstr2 { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? addstr3 { get; set; }
        public int? addint1 { get; set; }
        public int? addint3 { get; set; }
        public int? idaddclassification1 { get; set; }
        public int? idaddclassification2 { get; set; }
        public int? idaddclassification3 { get; set; }
        public int? idaddclassification4 { get; set; }
        public int? idaddclassification5 { get; set; }
        public int? pyrgrouping { get; set; }
        public int? idpreference { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? adddt1 { get; set; }

        [ForeignKey("idaddclassification1")]
        [InverseProperty("selleridaddclassification1Navigation")]
        public virtual addclassification? idaddclassification1Navigation { get; set; }
        [ForeignKey("idaddclassification2")]
        [InverseProperty("selleridaddclassification2Navigation")]
        public virtual addclassification? idaddclassification2Navigation { get; set; }
        [ForeignKey("idaddclassification3")]
        [InverseProperty("selleridaddclassification3Navigation")]
        public virtual addclassification? idaddclassification3Navigation { get; set; }
        [ForeignKey("idaddclassification4")]
        [InverseProperty("selleridaddclassification4Navigation")]
        public virtual addclassification? idaddclassification4Navigation { get; set; }
        [ForeignKey("idaddclassification5")]
        [InverseProperty("selleridaddclassification5Navigation")]
        public virtual addclassification? idaddclassification5Navigation { get; set; }
        [ForeignKey("idsellergroup")]
        [InverseProperty("seller")]
        public virtual sellergroup? idsellergroupNavigation { get; set; }
        [InverseProperty("idsellerNavigation")]
        public virtual ICollection<agreement> agreement { get; set; }
        [InverseProperty("idsellerNavigation")]
        public virtual ICollection<customer> customer { get; set; }
        [InverseProperty("idsellerNavigation")]
        public virtual ICollection<customerpricechange> customerpricechange { get; set; }
        [InverseProperty("idsellerNavigation")]
        public virtual ICollection<customerpricechangehistory> customerpricechangehistory { get; set; }
        [InverseProperty("idsellerNavigation")]
        public virtual ICollection<destanationseller> destanationseller { get; set; }
        [InverseProperty("idsellerNavigation")]
        public virtual ICollection<orders> orders { get; set; }
        [InverseProperty("idsellerNavigation")]
        public virtual ICollection<paymentdoc> paymentdoc { get; set; }
        [InverseProperty("idsellerNavigation")]
        public virtual ICollection<pricelist> pricelist { get; set; }
        [InverseProperty("idsellerNavigation")]
        public virtual ICollection<sellerdestanation> sellerdestanation { get; set; }
        [InverseProperty("idsellerNavigation")]
        public virtual ICollection<sellerpricechange> sellerpricechange { get; set; }
        [InverseProperty("idsellerNavigation")]
        public virtual ICollection<storedoc> storedoc { get; set; }
        [InverseProperty("idsellerNavigation")]
        public virtual ICollection<supplydoc> supplydoc { get; set; }
    }
}
