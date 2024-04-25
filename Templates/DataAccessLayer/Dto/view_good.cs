using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_good
    {
        public int idgood { get; set; }
        public int? idmeasure { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? marking { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? typ { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? extmarking { get; set; }
        public int? height { get; set; }
        public int? width { get; set; }
        public int? thick { get; set; }
        public int? idgoodgroup { get; set; }
        public short? usehouse { get; set; }
        public short? ismy { get; set; }
        public int? thickness { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price1 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price2 { get; set; }
        public int? idsystem { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? waste { get; set; }
        public int? idvalut { get; set; }
        public int? idcolor1 { get; set; }
        public int? idcolor2 { get; set; }
        public int? idgoodtype { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? minost { get; set; }
        public byte[]? price1crypt { get; set; }
        public int? idgoodpricegroup { get; set; }
        public int? idgoodoptim { get; set; }
        public Guid guid { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price3 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price4 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price5 { get; set; }
        public int? idvalut2 { get; set; }
        public int? idvalut3 { get; set; }
        public int? idvalut4 { get; set; }
        public int? idvalut5 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? packing { get; set; }
        public int? idgoodtype2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? weight { get; set; }
        public int? idstoredepart { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sqr { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sqr2 { get; set; }
        [Column(TypeName = "numeric(10, 2)")]
        public decimal? waste2 { get; set; }
        [Column(TypeName = "numeric(10, 2)")]
        public decimal? waste3 { get; set; }
        [Column(TypeName = "numeric(10, 2)")]
        public decimal? waste4 { get; set; }
        [Column(TypeName = "numeric(10, 2)")]
        public decimal? waste5 { get; set; }
        public short? showinnopaper { get; set; }
        public int? idcolorgroupcustom { get; set; }
        public int? idcustomer { get; set; }
        public short? replenishment { get; set; }
        public byte[]? picture { get; set; }
        public short? deliverytime { get; set; }
        public bool? reserve { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? maxost { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? minost2 { get; set; }
        public int? idstoragespace { get; set; }
        public short? purchase { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? rank1 { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? rank2 { get; set; }
        [StringLength(12)]
        [Unicode(false)]
        public string? measure_shortname { get; set; }
        public int? measure_typ { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? measure_factor { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? goodgroup_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? system_name { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? valut_shortname { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? color1_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? color1_groupname { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? color2_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? color2_groupname { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? goodtype_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? goodtype_name2 { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? goodpricegroup_name { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? goodpricegroup_price1 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? goodpricegroup_price2 { get; set; }
        public short? goodgroup_isactive { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? goodoptim_name { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? color1_shortname { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? color2_shortname { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? valut2_shortname { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? valut3_shortname { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? valut4_shortname { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? valut5_shortname { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? storedepart_name { get; set; }
        public short? goodgroup_isvisible { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? colorgroupcustom_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? customer_name { get; set; }
        [StringLength(13)]
        [Unicode(false)]
        public string? replenishment_name { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? goodmeasure_default { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? purchase_name { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? good_nac { get; set; }
    }
}
