using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_destanation
    {
        public int iddestanation { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? destanationgroup { get; set; }
        public int? idpyramid { get; set; }
        public int? numpos { get; set; }
        public Guid guid { get; set; }
        public int? addint1 { get; set; }
        public int? addint2 { get; set; }
        public int? addint3 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addnum1 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addnum2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addnum3 { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? addstr1 { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? addstr2 { get; set; }
        [Unicode(false)]
        public string? addstr3 { get; set; }
        public int? idroute { get; set; }
        public int? idpreference { get; set; }
        public int? pyrgrouping { get; set; }
        public int? transit { get; set; }
        public int? maxpyr { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? factory { get; set; }
        public int? pyrgroup { get; set; }
        public int? idproductionsite { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? pyramid_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? productionsite_name { get; set; }
    }
}
