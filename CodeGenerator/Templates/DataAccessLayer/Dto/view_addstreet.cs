using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_addstreet
    {
        public int idaddstreet { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? name { get; set; }
        public int? idaddcityregion { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public Guid guid { get; set; }
        public int? postindex { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? kladrcode { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? shortname { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? region_name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? area_name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? city_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? city_shortname { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? cityregion_name { get; set; }
        public int idaddregion { get; set; }
        public int idaddarea { get; set; }
        public int idaddcity { get; set; }
    }
}
