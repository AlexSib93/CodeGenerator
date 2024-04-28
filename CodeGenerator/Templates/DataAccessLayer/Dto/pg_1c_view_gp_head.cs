using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class pg_1c_view_gp_head
    {
        public int idproductiondoc { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? pd_name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtdoc { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dt_check { get; set; }
        [StringLength(31)]
        [Unicode(false)]
        public string? idseller { get; set; }
        [StringLength(12)]
        [Unicode(false)]
        public string seller_name { get; set; } = null!;
        [StringLength(5)]
        [Unicode(false)]
        public string sklad { get; set; } = null!;
        public int idsklad { get; set; }
        public int idmanufactdoc { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name_mf { get; set; }
    }
}
