using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_pricelist
    {
        public int idpricelist { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? idpeople { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtdoc { get; set; }
        [Column(TypeName = "image")]
        public byte[]? picture { get; set; }
        public byte[]? classnative { get; set; }
        [Column("class")]
        public byte[]? _class { get; set; }
        public int? idversion { get; set; }
        public int? idpricelistgroup { get; set; }
        public int? iddocoper { get; set; }
        public int? idversion2 { get; set; }
        public int? idvalut { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? valutrate { get; set; }
        public int? idorderdocoper { get; set; }
        public short? modeltype { get; set; }
        public int? iddocstate { get; set; }
        public int? idproductiontype { get; set; }
        public int? idcustomer { get; set; }
        public int? idseller { get; set; }
        [StringLength(194)]
        [Unicode(false)]
        public string? people_fio { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? docoper_name { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? orderdocoper_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? version_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? version_name2 { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? valut_shortname { get; set; }
        [StringLength(4000)]
        public string? model_profilesystem { get; set; }
        [StringLength(4000)]
        public string? model_furnituresystem { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? docstate_name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? productiontype_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? customer_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? seller_name { get; set; }
    }
}
