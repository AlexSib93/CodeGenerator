using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_glass
    {
        public int idglass { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? marking { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? color { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? glassgroup { get; set; }
        public int? ramkaoffset { get; set; }
        public int? numpos { get; set; }
        public int? thickness { get; set; }
        public int? camernost { get; set; }
        public int? idglassgroup { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? marking2 { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? marking3 { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? marking4 { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? marking5 { get; set; }
        public Guid guid { get; set; }
        public int? idfilltype { get; set; }
        [StringLength(19)]
        [Unicode(false)]
        public string filltype_name { get; set; } = null!;
        [StringLength(128)]
        [Unicode(false)]
        public string? glassgroup_name { get; set; }
    }
}
