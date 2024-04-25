using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("guid", Name = "UQ__pricechange__7A7DD359", IsUnique = true)]
    [Index("idpricechangegroup", Name = "idx_pricechange_idpricechangegroup")]
    public partial class pricechange
    {
        public pricechange()
        {
            customerpricechange = new HashSet<customerpricechange>();
            customerpricechangehistory = new HashSet<customerpricechangehistory>();
            customerpricepolicy = new HashSet<customerpricepolicy>();
            customerpricepolicyhistory = new HashSet<customerpricepolicyhistory>();
            orderpricechange = new HashSet<orderpricechange>();
            pricechangegrant = new HashSet<pricechangegrant>();
            pricelistpricechange = new HashSet<pricelistpricechange>();
            productiontype = new HashSet<productiontype>();
            productiontypesystems = new HashSet<productiontypesystems>();
            sellerpricechange = new HashSet<sellerpricechange>();
        }

        [Key]
        public int idpricechange { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public short? typ { get; set; }
        public short? fororder { get; set; }
        public short? isperc { get; set; }
        public int? idpricechangegroup { get; set; }
        public Guid guid { get; set; }
        public int? numpos { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? defaultvalue { get; set; }
        /// <summary>
        /// Переносить в дилерскую версию
        /// </summary>
        public bool? indealerbase { get; set; }
        /// <summary>
        /// Видимость в дилерской версии
        /// </summary>
        public bool? visibledealer { get; set; }

        [ForeignKey("idpricechangegroup")]
        [InverseProperty("pricechange")]
        public virtual pricechangegroup? idpricechangegroupNavigation { get; set; }
        [InverseProperty("idpricechangeNavigation")]
        public virtual ICollection<customerpricechange> customerpricechange { get; set; }
        [InverseProperty("idpricechangeNavigation")]
        public virtual ICollection<customerpricechangehistory> customerpricechangehistory { get; set; }
        [InverseProperty("idpricechangeNavigation")]
        public virtual ICollection<customerpricepolicy> customerpricepolicy { get; set; }
        [InverseProperty("idpricechangeNavigation")]
        public virtual ICollection<customerpricepolicyhistory> customerpricepolicyhistory { get; set; }
        [InverseProperty("idpricechangeNavigation")]
        public virtual ICollection<orderpricechange> orderpricechange { get; set; }
        [InverseProperty("idpricechangeNavigation")]
        public virtual ICollection<pricechangegrant> pricechangegrant { get; set; }
        [InverseProperty("idpricechangeNavigation")]
        public virtual ICollection<pricelistpricechange> pricelistpricechange { get; set; }
        [InverseProperty("idpricechangeNavigation")]
        public virtual ICollection<productiontype> productiontype { get; set; }
        [InverseProperty("idpricechangeNavigation")]
        public virtual ICollection<productiontypesystems> productiontypesystems { get; set; }
        [InverseProperty("idpricechangeNavigation")]
        public virtual ICollection<sellerpricechange> sellerpricechange { get; set; }
    }
}
