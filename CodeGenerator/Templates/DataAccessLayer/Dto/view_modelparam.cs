using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_modelparam
    {
        public int idmodelparam { get; set; }
        public int? idmodelpart { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? intvalue { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? strvalue { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? strvalue2 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public short? saved { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? comment { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        public int? idversion { get; set; }
        public int? numpos { get; set; }
        public int? idmodelpartroot { get; set; }
        public short? onlyfromlist { get; set; }
        public short? isactive { get; set; }
        public Guid guid { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? constrtypelist { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? systemlist { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? opentypelist { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? unvisiblestrvalue { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? unvisiblestrvalue2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? unvisibleintvalue { get; set; }
        public bool? isdesignerprocess { get; set; }
        public int? idmodelparamgroup { get; set; }
        public bool tomodel { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? furnsystemlist { get; set; }
        public bool? isstr1 { get; set; }
        public bool? isstr2 { get; set; }
        public bool? isint1 { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? namestr1 { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? namestr2 { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? nameint1 { get; set; }
        public bool? iscolor { get; set; }
        public int? idcolor { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? namecolor { get; set; }
        [Unicode(false)]
        public string? colorfilter { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? intvalue2 { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? nameint2 { get; set; }
        public bool? isint2 { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? groupname { get; set; }
        public bool? useunvisible { get; set; }
        [StringLength(128)]
        public string? name_strkey { get; set; }
        [StringLength(128)]
        public string? strvalue_strkey { get; set; }
        [StringLength(128)]
        public string? strvalue2_strkey { get; set; }
        [StringLength(512)]
        public string? unvisiblestrvalue_strkey { get; set; }
        [StringLength(512)]
        public string? unvisiblestrvalue2_strkey { get; set; }
        public bool? ui_visible { get; set; }
        public int? sortorder { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? modelpart_name { get; set; }
        [StringLength(193)]
        [Unicode(false)]
        public string? color_name { get; set; }
    }
}
