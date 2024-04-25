using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_pyramid
    {
        public int idpyramid { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? numpos { get; set; }
        public int? qurow { get; set; }
        public int? rowlen { get; set; }
        public Guid guid { get; set; }
        public int? height { get; set; }
        public int? width { get; set; }
        public int? depth { get; set; }
        public int? maxwiwidth { get; set; }
        public int? weight { get; set; }
        public int? selfdepth { get; set; }
        public int? maxrowwidth { get; set; }
        public int? idcar { get; set; }
        public bool doublesided { get; set; }
        public int? qufirstrow { get; set; }
        public int? maxheightfirstrow { get; set; }
        public byte state { get; set; }
        [StringLength(12)]
        [Unicode(false)]
        public string? state_name { get; set; }
        public int? idproductionsite { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? productionsite_name { get; set; }
        public int? priority { get; set; }
    }
}
