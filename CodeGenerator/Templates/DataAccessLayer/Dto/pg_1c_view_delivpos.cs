using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class pg_1c_view_delivpos
    {
        public int idorder { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name_o { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? orderitem_marking { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? orderitem_name { get; set; }
        public int? oi_numpos { get; set; }
        public int? orderitemnum { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? customer_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? seller_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? d_name { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? qu { get; set; }
        public int iddelivdoc { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price { get; set; }
        public int skidka { get; set; }
        public int perc_skidka { get; set; }
        public int usl { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal pricebase { get; set; }
        public int pricechange { get; set; }
        [StringLength(8)]
        [Unicode(false)]
        public string sklad { get; set; } = null!;
        [StringLength(31)]
        [Unicode(false)]
        public string? idnom { get; set; }
        [StringLength(12)]
        [Unicode(false)]
        public string? measure_shortname { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? pt_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? destanation_name { get; set; }
        public int idorderitem { get; set; }
        public int? iddestanation { get; set; }
    }
}
