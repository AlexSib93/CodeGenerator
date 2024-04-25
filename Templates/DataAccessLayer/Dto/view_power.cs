using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_power
    {
        public int idpower { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? typ { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? maxval { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? powergroup { get; set; }
        public Guid guid { get; set; }
        public bool checkpower { get; set; }
        public int duration { get; set; }
        public int? idproductionsite { get; set; }
        [Unicode(false)]
        public string? model { get; set; }
        public int? iddiraction1 { get; set; }
        public int? iddiraction2 { get; set; }
        public int? idfinparam { get; set; }
        public int? parentid { get; set; }
        public int? idganttchart { get; set; }
        public int? iddocoper { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? limit { get; set; }
        public bool? need_more_precise { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? typ_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? productionsite_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? ganttchart_name { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? docoper_name { get; set; }
    }
}
