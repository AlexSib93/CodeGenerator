using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_versions
    {
        public int idversion { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? versiondate { get; set; }
        [Column(TypeName = "text")]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? versiongroup { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? versiondate2 { get; set; }
        public short? typ { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? serial { get; set; }
        public Guid guid { get; set; }
        [StringLength(11)]
        [Unicode(false)]
        public string? typ_name { get; set; }
    }
}
