using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_pricelistpricechange
    {
        public int idpricelistpricechange { get; set; }
        public int? idpricelist { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? perc { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase { get; set; }
        public int? idvalut { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? valutrate { get; set; }
        public int? idpricechange { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? pricechange_name { get; set; }
        [StringLength(7)]
        [Unicode(false)]
        public string? pricechange_typ { get; set; }
        public short? fororder { get; set; }
        [StringLength(11)]
        [Unicode(false)]
        public string? fororder_typ { get; set; }
        public short? pricechange_typ2 { get; set; }
        public short? pricechange_isperc { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? valut_shortname { get; set; }
    }
}
