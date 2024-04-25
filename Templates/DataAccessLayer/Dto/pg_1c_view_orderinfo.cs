using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class pg_1c_view_orderinfo
    {
        [StringLength(31)]
        [Unicode(false)]
        public string? idcustomer { get; set; }
        [StringLength(31)]
        [Unicode(false)]
        public string? idseller { get; set; }
        public int idorder { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? docstate_name { get; set; }
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtdoc { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dt_prin { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dt_otgr { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dt_check { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? customer_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? seller_name { get; set; }
        [StringLength(5)]
        [Unicode(false)]
        public string sklad { get; set; } = null!;
        public int idsklad { get; set; }
        public int in_pz { get; set; }
    }
}
