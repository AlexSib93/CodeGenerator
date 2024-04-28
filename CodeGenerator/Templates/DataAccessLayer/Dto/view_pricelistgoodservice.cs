using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_pricelistgoodservice
    {
        public int idpricelistgoodservice { get; set; }
        public int? idpricelist { get; set; }
        public int? idgoodservice { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? perc { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase { get; set; }
        public int? idvalut { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? valutrate { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? qu { get; set; }
        public int? idpricelistitem { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price2 { get; set; }
        public short? iscalc { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm2 { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? goodservice_name { get; set; }
        public short? goodservice_isperc { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? valut_shortname { get; set; }
        public long? pricelistitem_numpos { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? goodservice_groupname { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? goodservice_goodservicegroup { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? goodservice_price1 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? goodservice_price2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? goodservice_price3 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? goodservice_price4 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? goodservice_price5 { get; set; }
        public int? goodservice_idvalut1 { get; set; }
        public int? goodservice_idvalut2 { get; set; }
        public int? goodservice_idvalut3 { get; set; }
        public int? goodservice_idvalut4 { get; set; }
        public int? goodservice_idvalut5 { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? goodservice_comment { get; set; }
        public bool? goodservice_ismy { get; set; }
        public Guid? goodservice_guid { get; set; }
    }
}
