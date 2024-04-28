using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class pg_1c_view_gp
    {
        public int idorder { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? order_name { get; set; }
        [StringLength(31)]
        [Unicode(false)]
        public string? idnom { get; set; }
        public int? o_idseller { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? o_seller_name { get; set; }
        public int? idcustomer { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? customer_name { get; set; }
        public int idsklad { get; set; }
        [StringLength(8)]
        [Unicode(false)]
        public string sklad { get; set; } = null!;
        public int idorderitem { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? orderitem_marking { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? orderitem_name { get; set; }
        public int? orderitem_numpos { get; set; }
        public int qu { get; set; }
        public int usl { get; set; }
        public int? orderitemnum { get; set; }
        public int idmanufactdocpos { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? o_dtdoc { get; set; }
        public int? idrotoxhouse { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? row { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? cell { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtin { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price { get; set; }
        [Column(TypeName = "numeric(16, 4)")]
        public decimal? skidka { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? pt_name { get; set; }
        [StringLength(31)]
        [Unicode(false)]
        public string? idseller { get; set; }
        [StringLength(12)]
        [Unicode(false)]
        public string seller_name { get; set; } = null!;
        [StringLength(12)]
        [Unicode(false)]
        public string? measure_shortname { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? pd_name { get; set; }
        public int idproductiondoc { get; set; }
    }
}
