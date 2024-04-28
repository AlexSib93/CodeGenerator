using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_orderpricechange
    {
        public int idorderpricechange { get; set; }
        public int? idorder { get; set; }
        public int? idorderitem { get; set; }
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
        public int? idpeopleedit { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtedit { get; set; }
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
        public int? orderitem_numpos { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? orderitem_name { get; set; }
        [StringLength(194)]
        [Unicode(false)]
        public string? peopleedit_fio { get; set; }
    }
}
