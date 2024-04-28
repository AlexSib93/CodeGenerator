using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_goodcolorgroupprice
    {
        public int idgoodcolorgroupprice { get; set; }
        public int idcolorgroupprice { get; set; }
        public int idvalut { get; set; }
        public int idgood { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? k1 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? k2 { get; set; }
        public int? idgoodpricegroup { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? planprice { get; set; }
        public int? idvalut2 { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? colorgroupprice_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? good_marking { get; set; }
        [Column(TypeName = "numeric(31, 8)")]
        public decimal? price_k1 { get; set; }
        [Column(TypeName = "numeric(38, 6)")]
        public decimal? price_k2 { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? valut_shortname { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? goodpricegroup_name { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? diffprice { get; set; }
    }
}
