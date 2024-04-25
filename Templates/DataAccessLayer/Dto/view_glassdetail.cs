using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_glassdetail
    {
        public int idglassdetail { get; set; }
        public int? idglass { get; set; }
        public int? idgood { get; set; }
        public short? typ { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public Guid guid { get; set; }
        public int? idglasselement { get; set; }
        [StringLength(6)]
        [Unicode(false)]
        public string typ_name { get; set; } = null!;
        [StringLength(128)]
        [Unicode(false)]
        public string? good_marking { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? good_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? glasselement_marking { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? glasselement_name { get; set; }
    }
}
