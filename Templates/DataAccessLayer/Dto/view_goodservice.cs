using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_goodservice
    {
        [StringLength(50)]
        [Unicode(false)]
        public string? group_name { get; set; }
        public short? group_isactive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? group_deleted { get; set; }
        public int idgoodservice { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? perc { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? goodservicegroup { get; set; }
        public short? isperc { get; set; }
        public int? idgoodservicegroup { get; set; }
        public Guid guid { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price1 { get; set; }
        public int? idvalut1 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price2 { get; set; }
        public int? idvalut2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price3 { get; set; }
        public int? idvalut3 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price4 { get; set; }
        public int? idvalut4 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price5 { get; set; }
        public int? idvalut5 { get; set; }
        public bool? ismy { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? valut1_shortname { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? valut2_shortname { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? valut3_shortname { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? valut4_shortname { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? valut5_shortname { get; set; }
    }
}
