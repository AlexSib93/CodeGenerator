using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_sizedocconstrtype
    {
        public int idsizedocconstrtype { get; set; }
        public int? idsizedoc { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? idconstructiontype { get; set; }
        public int? qu { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sqr { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? winue { get; set; }
        public int? idembrasuretype { get; set; }
        public bool? numpos { get; set; }
        public int? thick { get; set; }
        public int? width { get; set; }
        public int? height { get; set; }
        public int? idproductiontype { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string construction_name { get; set; } = null!;
        [StringLength(256)]
        [Unicode(false)]
        public string embrasuretype_name { get; set; } = null!;
        [StringLength(50)]
        [Unicode(false)]
        public string embrasuretype_shortname { get; set; } = null!;
        [StringLength(256)]
        [Unicode(false)]
        public string productiontype_name { get; set; } = null!;
    }
}
