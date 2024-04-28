using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class pg_1c_view_supply
    {
        public int idsupplydoc { get; set; }
        [StringLength(31)]
        [Unicode(false)]
        public string idcustomer { get; set; } = null!;
        [StringLength(128)]
        [Unicode(false)]
        public string customer_name { get; set; } = null!;
        [StringLength(4)]
        [Unicode(false)]
        public string idorganization { get; set; } = null!;
        [StringLength(12)]
        [Unicode(false)]
        public string org_name { get; set; } = null!;
        [StringLength(64)]
        [Unicode(false)]
        public string? docoper_name { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dt_check { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? sd_name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? sd_dtdoc { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
    }
}
