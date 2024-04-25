using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_installdocgoodservice
    {
        public int idinstalldocgoodservice { get; set; }
        public int? idinstalldoc { get; set; }
        public int? idinstalldocpos { get; set; }
        public int? idorder { get; set; }
        public int? idorderitem { get; set; }
        public int? idgoodservice { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase2 { get; set; }
        public int? idvalut { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? valutrate { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? qu { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price2 { get; set; }
        public short? iscalc { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? goodservice_name { get; set; }
        public short? goodservice_isperc { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? valut_shortname { get; set; }
        public int? installdocpos_numpos { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? goodservice_groupname { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? goodservice_goodservicegroup { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? order_agreename { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? order_agreedate { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? order_name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? order_dtdoc { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? orderitem_name { get; set; }
        public int? orderitem_numpos { get; set; }
    }
}
