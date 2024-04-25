using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_allgoodfromorderprice
    {
        public int? idorder { get; set; }
        public int? idorderitem { get; set; }
        public int? idmodel { get; set; }
        public int? idgood { get; set; }
        public int? good_idgoodtype { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? good_marking { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? good_name { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? good_waste { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? goodgroup_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? goodtype_name { get; set; }
        public int? goodtype_numpos { get; set; }
        public int? orderitem_numpos { get; set; }
        public int thick { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal weight { get; set; }
        [Column(TypeName = "numeric(38, 8)")]
        public decimal? sqr { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? measure_factor { get; set; }
        [StringLength(12)]
        [Unicode(false)]
        public string? measure_shortname { get; set; }
        public int? measure_typ { get; set; }
        [Column(TypeName = "numeric(38, 4)")]
        public decimal? qu { get; set; }
        [Column(TypeName = "numeric(38, 4)")]
        public decimal? qustore { get; set; }
        [Column(TypeName = "numeric(38, 4)")]
        public decimal? smbase { get; set; }
        [Column(TypeName = "numeric(38, 4)")]
        public decimal? sm { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? pricebase { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? radius1 { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? radius2 { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? ang1 { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? ang2 { get; set; }
        public int? idcolor1 { get; set; }
        public int? idcolor2 { get; set; }
    }
}
