using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_goodoptim
    {
        public int idgoodoptim { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? whiplen { get; set; }
        public int? worklen { get; set; }
        public int? step { get; set; }
        public int? freza { get; set; }
        public int? buffer { get; set; }
        public int? dl { get; set; }
        public int? dr { get; set; }
        public int? dt { get; set; }
        public int? db { get; set; }
        public int? drez { get; set; }
        public int? maxrez { get; set; }
        public short? typ { get; set; }
        public int? width { get; set; }
        public int? height { get; set; }
        public Guid guid { get; set; }
        public short? canrotate { get; set; }
        public int? typerez { get; set; }
        public int? optimtype { get; set; }
        public int? maxworkrests { get; set; }
        public short typeoptimend { get; set; }
        public short dopuskoptim { get; set; }
        public int? ostmin { get; set; }
        public int? ostmax { get; set; }
        public int? minost { get; set; }
        public byte optimstyle { get; set; }
        public int? differentwhipsforbeamsize { get; set; }
        public int? divideremainder { get; set; }
        public int? worklen_width { get; set; }
        public int? worklen_height { get; set; }
        public byte quality { get; set; }
        [StringLength(11)]
        [Unicode(false)]
        public string typ_name { get; set; } = null!;
        [StringLength(14)]
        [Unicode(false)]
        public string typerez_name { get; set; } = null!;
        [StringLength(10)]
        [Unicode(false)]
        public string optimtype_name { get; set; } = null!;
        [StringLength(15)]
        [Unicode(false)]
        public string typeoptimend_name { get; set; } = null!;
        [StringLength(10)]
        [Unicode(false)]
        public string optimstyle_name { get; set; } = null!;
        [StringLength(10)]
        [Unicode(false)]
        public string quality_name { get; set; } = null!;
    }
}
