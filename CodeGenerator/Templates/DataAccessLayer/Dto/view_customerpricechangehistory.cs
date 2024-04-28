using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_customerpricechangehistory
    {
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
        [StringLength(194)]
        [Unicode(false)]
        public string people_fio { get; set; } = null!;
        [StringLength(128)]
        [Unicode(false)]
        public string? pricechange_name { get; set; }
    }
}
