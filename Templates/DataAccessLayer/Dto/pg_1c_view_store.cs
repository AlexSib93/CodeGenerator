using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class pg_1c_view_store
    {
        public int idstoredoc { get; set; }
        [StringLength(31)]
        [Unicode(false)]
        public string? idcustomer { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? customer_name { get; set; }
        [StringLength(4)]
        [Unicode(false)]
        public string idorganization { get; set; } = null!;
        [StringLength(12)]
        [Unicode(false)]
        public string org_name { get; set; } = null!;
        public int? idpoluchatel { get; set; }
        public int? idotpravitel { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? poluchatel { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? otpravitel { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? docoper_name { get; set; }
        public int? iddocoper { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dt_check { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? sd_name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? sd_dtdoc { get; set; }
        public int? idsupplydoc { get; set; }
        public int in_per { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int is_lamin { get; set; }
        public int? idproductiondoc { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? pd_name { get; set; }
    }
}
