using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_storedocpos
    {
        public int idstoredocpos { get; set; }
        public int? idstoredoc { get; set; }
        public int? idgood { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? qu { get; set; }
        public int? height { get; set; }
        public int? width { get; set; }
        public int? thick { get; set; }
        public int? numpos { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? part { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm { get; set; }
        [Column(TypeName = "numeric(15, 6)")]
        public decimal? qustore { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? weight { get; set; }
        public int? idorderitem { get; set; }
        public int? idvalut { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? valutrate { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? pricebase { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase { get; set; }
        public int? color1 { get; set; }
        public int? color2 { get; set; }
        public int? idcolor1 { get; set; }
        public int? idcolor2 { get; set; }
        public int? idgoodmeasure { get; set; }
        public int? idmanufactdocpos { get; set; }
        public int? parentid { get; set; }
        public int? row { get; set; }
        public int? cell { get; set; }
        public int? idsupplydocpos { get; set; }
        public int? idgood2 { get; set; }
        public int? idstoragespace { get; set; }
        public int? idproductiondocpos { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sumnds { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? nds { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? pricebasends { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? good_marking { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? good_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? good2_marking { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? good2_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? goodtype_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? goodtype_name2 { get; set; }
        [StringLength(12)]
        [Unicode(false)]
        public string? measure_shortname { get; set; }
        public int? measure_typ { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? measure_factor { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? good_valutshortname { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? valut_shortname { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? color1_name { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? color2_name { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? goodmeasure_name { get; set; }
        public int? manufactdocpos_numpos { get; set; }
        public int? orderitem_numpos { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? manufactdoc_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? orders_name { get; set; }
        [StringLength(35)]
        [Unicode(false)]
        public string? storagespace { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? goodgroup_name { get; set; }
    }
}
