using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_manufactdocpos_plan
    {
        public int idmanufactdocpos { get; set; }
        public int? idmanufactdoc { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? qu { get; set; }
        public int? numpos { get; set; }
        public int? thick { get; set; }
        public int? idorderitem { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? posgroup { get; set; }
        public int? height { get; set; }
        public int? width { get; set; }
        public int? idgood { get; set; }
        public int? numpyramid { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? quready { get; set; }
        public int? parentid { get; set; }
        public int? idordergood { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? modelpart { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? weight { get; set; }
        public int? idmodelcalc { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? manufactname { get; set; }
        public int? orderitemnum { get; set; }
        public int? cart { get; set; }
        public int? cell { get; set; }
        [StringLength(40)]
        [Unicode(false)]
        public string? barcode { get; set; }
        public bool? addbit1 { get; set; }
        public bool? addbit2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? orderitem_qu { get; set; }
        public int? orderitem_thick { get; set; }
        public int? orderitem_height { get; set; }
        public int? orderitem_width { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? orderitem_weight { get; set; }
        public short? orderitem_typ { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? orderitem_name { get; set; }
        public int? idorder { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? good_marking { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? good_name { get; set; }
        public int? orderitem_idmodel { get; set; }
        public int? orderitem_numpos { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? order_name { get; set; }
        public byte[]? model_class { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? customer_name { get; set; }
        public int? _quglass { get; set; }
        [Column(TypeName = "numeric(26, 4)")]
        public decimal? qu_glass { get; set; }
        public int? _qustv { get; set; }
        [Column(TypeName = "numeric(26, 4)")]
        public decimal? qu_stv { get; set; }
        public byte[]? model_picture { get; set; }
        [StringLength(4000)]
        public string? system_prof { get; set; }
        [StringLength(4000)]
        public string? system_furn { get; set; }
        public int? qu_dopprof { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? order_agreename { get; set; }
    }
}
