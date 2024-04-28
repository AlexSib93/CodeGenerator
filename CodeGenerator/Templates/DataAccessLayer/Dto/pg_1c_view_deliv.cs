using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class pg_1c_view_deliv
    {
        [StringLength(128)]
        [Unicode(false)]
        public string? d_name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? d_dtdoc { get; set; }
        [StringLength(31)]
        [Unicode(false)]
        public string? idcustomer { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? customer_name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dt_check { get; set; }
        public int iddelivdoc { get; set; }
        public int idsklad { get; set; }
        [StringLength(5)]
        [Unicode(false)]
        public string sklad { get; set; } = null!;
        [StringLength(31)]
        [Unicode(false)]
        public string? idseller { get; set; }
        [StringLength(12)]
        [Unicode(false)]
        public string seller_name { get; set; } = null!;
        public int in_pz { get; set; }
        public string? orders_not_in_1c { get; set; }
    }
}
