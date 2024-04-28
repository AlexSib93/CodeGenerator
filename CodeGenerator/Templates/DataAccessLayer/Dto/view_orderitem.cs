using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_orderitem
    {
        public int idorderitem { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        public int? idorder { get; set; }
        public int? idmodel { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? qu { get; set; }
        public int? thick { get; set; }
        public int? height { get; set; }
        public int? width { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm2 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? part { get; set; }
        public int? idgood { get; set; }
        public int? numpos { get; set; }
        public short? typ { get; set; }
        public int? idversion { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? qustore { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? pricebase { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? sqr { get; set; }
        public short? isglass { get; set; }
        public short? ismoskit { get; set; }
        public short? isaddgood { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? winue { get; set; }
        public short? isstandart { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? winue2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? winue3 { get; set; }
        public int? idpeopleedit { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtedit { get; set; }
        public int? constrnum { get; set; }
        public int? idprofsys { get; set; }
        public int? idfurnsys { get; set; }
        public int? idconstructiontype { get; set; }
        public int? idcolorin { get; set; }
        public int? idcolorout { get; set; }
        public int? quready { get; set; }
        public short? isready { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? radius1 { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? radius2 { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? ang1 { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? ang2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? weight { get; set; }
        public int? quinmanufact { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase3 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase4 { get; set; }
        public int? parentid { get; set; }
        [Unicode(false)]
        public string? comment { get; set; }
        public int? idproductiontype { get; set; }
        public int? idorderitemold { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addnum1 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addnum2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addnum3 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addnum4 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addnum5 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addnum6 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addnum7 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addnum8 { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? addstr { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? addstr2 { get; set; }
        public int? addint { get; set; }
        public int? addint2 { get; set; }
        public int? idgoodkitdetail { get; set; }
        public int? idgoodkit { get; set; }
        public bool? hide { get; set; }
        public int? idpower { get; set; }
        public bool? ispf { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? assemblyunit { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? model_name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? good_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? good_marking { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? good_waste { get; set; }
        public int? measure_typ { get; set; }
        [StringLength(12)]
        [Unicode(false)]
        public string measure_shortname { get; set; } = null!;
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? measure_factor { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? goodtype_name { get; set; }
        public int? good_idgoodtype { get; set; }
        public int? good_idgoodtype2 { get; set; }
        public int? goodtype_numpos { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? goodtype_name2 { get; set; }
        public int? goodtype_numpos2 { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? mdoc_name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? mdoc_dt { get; set; }
        [Column(TypeName = "numeric(38, 4)")]
        public decimal? mdoc_qu { get; set; }
        public int? good_idgoodgroup { get; set; }
        public short? good_ismy { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? goodgroup_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? profsys_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? furnsys_name { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? constrtype_name { get; set; }
        public int? good_idcolor1 { get; set; }
        public int? good_idcolor2 { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string colorin_name { get; set; } = null!;
        [StringLength(64)]
        [Unicode(false)]
        public string colorout_name { get; set; } = null!;
        [StringLength(256)]
        [Unicode(false)]
        public string? productiontype_name { get; set; }
        public int? productiontype_typ { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? productiontype_productiontypegroup { get; set; }
        public int vdfield1 { get; set; }
        [Column(TypeName = "numeric(31, 6)")]
        public decimal? sqrtotal { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? power_name { get; set; }
        [StringLength(64)]
        public string? colorin_name_strkey { get; set; }
        [StringLength(64)]
        public string? colorout_name_strkey { get; set; }
        [StringLength(64)]
        public string? constrtype_name_strkey { get; set; }
        [StringLength(128)]
        public string? profsys_name_strkey { get; set; }
        [StringLength(128)]
        public string? furnsys_name_strkey { get; set; }
    }
}
