using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class pg_1c_view_orderpos
    {
        public int idorder { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? marking { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? name { get; set; }
        public int? idcolor1 { get; set; }
        public int? idcolor2 { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? c1_name { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? c2_name { get; set; }
        [StringLength(31)]
        [Unicode(false)]
        public string? idnom { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price { get; set; }
        public int skidka { get; set; }
        public int perc_skidka { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? oi_qu { get; set; }
        [StringLength(31)]
        [Unicode(false)]
        public string? id { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? pid { get; set; }
        public bool? hide { get; set; }
        public int isprod { get; set; }
        public int usl { get; set; }
        [StringLength(12)]
        [Unicode(false)]
        public string? measure_shortname { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? nom_name { get; set; }
    }
}
