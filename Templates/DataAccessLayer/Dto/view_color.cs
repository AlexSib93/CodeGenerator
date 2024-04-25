using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_color
    {
        public int idcolor { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? color { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? colorgroup { get; set; }
        public short? windraw { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? shortname { get; set; }
        public int? idcolorgroup { get; set; }
        public Guid guid { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? numvalue1 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? numvalue2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? numvalue3 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? numvalue4 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? numvalue5 { get; set; }
        public int? numpos { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? outername { get; set; }
        [StringLength(64)]
        public string? name_strkey { get; set; }
        [StringLength(32)]
        public string? shortname_strkey { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? colorgroup_name { get; set; }
        public int? parentid { get; set; }
        public short? isactive { get; set; }
        [StringLength(128)]
        public string? colorgroup_name_strkey { get; set; }
    }
}
