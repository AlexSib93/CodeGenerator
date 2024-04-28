using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_customerpricepolicyhistory
    {
        public int idcustomerpricepolicyhistory { get; set; }
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
        public int? idpeople { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dt { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? comment { get; set; }
        [StringLength(194)]
        [Unicode(false)]
        public string people_fio { get; set; } = null!;
        [StringLength(128)]
        [Unicode(false)]
        public string? pricechange_name { get; set; }
    }
}
