using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_supplydocpos
    {
        public int idsupplydocpos { get; set; }
        public int? idsupplydoc { get; set; }
        public int? numpos { get; set; }
        public int? idgood { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? qu { get; set; }
        public int? width { get; set; }
        public int? height { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? weight { get; set; }
        public int? thick { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? pricebase { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase { get; set; }
        public int? idorderitem { get; set; }
        public int? idmodel { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? qustore { get; set; }
        public int? parentid { get; set; }
        public int? idcolor1 { get; set; }
        public int? idcolor2 { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? radius1 { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? radius2 { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? ang1 { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? ang2 { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? modelpart { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? addstr { get; set; }
        [Column(TypeName = "numeric(20, 5)")]
        public decimal? addint { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? addstr2 { get; set; }
        public int? thickness { get; set; }
        public int? idmanufactdocpos { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? addstr3 { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? addstr4 { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? addstr5 { get; set; }
        public int? idgoodmeasure { get; set; }
        public int? idgood2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sumnds { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? nds { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? pricebasends { get; set; }
        public int? orderitemnum { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? good_marking { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? good_name { get; set; }
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
        public string? goodtype_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? good2_marking { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? good2_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? order_name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? oreder_dtdoc { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? order_agreename { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? order_agreedate { get; set; }
        public int? orderitem_numpos { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? orderitem_name { get; set; }
        public int? manufactdoc_numpos { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? manufactdoc_name { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string good_colorinname { get; set; } = null!;
        [StringLength(64)]
        [Unicode(false)]
        public string good_coloroutname { get; set; } = null!;
        [StringLength(64)]
        [Unicode(false)]
        public string? goodmeasure_name { get; set; }
    }
}
