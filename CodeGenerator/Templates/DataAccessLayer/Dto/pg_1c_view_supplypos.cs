using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class pg_1c_view_supplypos
    {
        public int idsupplydoc { get; set; }
        [StringLength(31)]
        [Unicode(false)]
        public string? idcustomer { get; set; }
        [StringLength(31)]
        [Unicode(false)]
        public string? idnom { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? marking { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(31)]
        [Unicode(false)]
        public string? idnom_out { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? marking_out { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? name_out { get; set; }
        public int? idcolor1 { get; set; }
        public int? idcolor2 { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? c1_shortname { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? c2_shortname { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? qu { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? qustore { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? pricebase { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase { get; set; }
        public int? idmeasure { get; set; }
        [StringLength(12)]
        [Unicode(false)]
        public string? measure_shortname { get; set; }
        public int idmeasure_out { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? measure_shortname_out { get; set; }
        public int usluga { get; set; }
        public int skidka { get; set; }
    }
}
