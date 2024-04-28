using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    public partial class tariff
    {
        public tariff()
        {
            car = new HashSet<car>();
            cartariff = new HashSet<cartariff>();
            delivdoc = new HashSet<delivdoc>();
        }

        [Key]
        public int idtariff { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price2 { get; set; }

        [InverseProperty("idtariffNavigation")]
        public virtual ICollection<car> car { get; set; }
        [InverseProperty("idtariffNavigation")]
        public virtual ICollection<cartariff> cartariff { get; set; }
        [InverseProperty("idtariffNavigation")]
        public virtual ICollection<delivdoc> delivdoc { get; set; }
    }
}
