using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_productiondocpos
    {
        [StringLength(128)]
        [Unicode(false)]
        public string? order_name { get; set; }
        [Column(TypeName = "numeric(31, 8)")]
        public decimal? orderitem_qu { get; set; }
        public int idproductiondocpos { get; set; }
        public int? idproductiondoc { get; set; }
        public int? idorderitem { get; set; }
        public int? idmodel { get; set; }
        public int? qu { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? numpos { get; set; }
        public int? idgood { get; set; }
        public int? idpeopleedit { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtedit { get; set; }
        public int? idordergood { get; set; }
        public int? idmodelcalc { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? barnumpos { get; set; }
        public int? idmanufactdocpos { get; set; }
        public int? idstoredoc { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? orderitem_name { get; set; }
        public int? thick { get; set; }
        public int? height { get; set; }
        public int? width { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? weight { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? good_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? good_marking { get; set; }
    }
}
