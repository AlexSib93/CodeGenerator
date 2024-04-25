using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_manufactdocpyramid
    {
        public int idmanufactdocpyramid { get; set; }
        public int? idpyramid { get; set; }
        public int? idmanufactdocpos { get; set; }
        public int? idmanufactdoc { get; set; }
        public int? numpyramid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? idmanufactdoccar { get; set; }
        public byte[]? picture { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string? barcode { get; set; }
        public short side { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? order_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? order_agrename { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? order_agreedate { get; set; }
        public int idorder { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? orderitem_name { get; set; }
        public int? orderitem_numpos { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? orderitem_qu { get; set; }
        public int idorderitem { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? manufactdoc_name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? manufactdoc_dtdoc { get; set; }
    }
}
