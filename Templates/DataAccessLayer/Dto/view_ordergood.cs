using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_ordergood
    {
        public int idordergood { get; set; }
        public int? idgood { get; set; }
        public int? numpos { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? qu { get; set; }
        public int? thick { get; set; }
        public int? height { get; set; }
        public int? width { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? weight { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? ang1 { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? ang2 { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? radius1 { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? radius2 { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? idorderitem { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? qustore { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? pricebase { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sqr { get; set; }
        public int? idcolor1 { get; set; }
        public int? idcolor2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase3 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase4 { get; set; }
        public int? quinmanufact { get; set; }
        public int? quready { get; set; }
        public int? parentid { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? addstr { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? addstr2 { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? modelpart { get; set; }
        public int? addint { get; set; }
        public int? addint2 { get; set; }
        public int? idgoodkitdetail { get; set; }
        public int? idgoodkit { get; set; }
        public int? idorder { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? good_marking { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? good_name { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? good_waste { get; set; }
        public int? orderitem_numpos { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? orderitem_name { get; set; }
        [StringLength(12)]
        [Unicode(false)]
        public string? measure_shortname { get; set; }
        public int? measure_typ { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? measure_factor { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? goodtype_name { get; set; }
        public int? goodtype_numpos { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? goodtype_name2 { get; set; }
        public int? goodtype_numpos2 { get; set; }
        public int? good_idgoodtype { get; set; }
        public int? good_idgoodtype2 { get; set; }
        public int? good_idgoodgroup { get; set; }
        public short? good_ismy { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? goodgroup_name { get; set; }
        public int? good_idcolor1 { get; set; }
        public int? good_idcolor2 { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string colorout_name { get; set; } = null!;
        [StringLength(64)]
        [Unicode(false)]
        public string colorin_name { get; set; } = null!;
    }
}
