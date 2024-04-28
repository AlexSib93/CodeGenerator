using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_systemdetail
    {
        public int idsystemdetail { get; set; }
        public int? idsystem { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? a { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? b { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? c { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? d { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? e { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? f { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? g { get; set; }
        public int? thick { get; set; }
        public int? thickness { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? weight { get; set; }
        public int? height { get; set; }
        public int? width { get; set; }
        public int? idmodelpart { get; set; }
        public int? idversion { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? systemdetailgroup { get; set; }
        public int? numpos { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? steel { get; set; }
        public short? isactive { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? minang { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? maxang { get; set; }
        public int? minr { get; set; }
        public int? maxr { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sqr1 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sqr2 { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? z { get; set; }
        public byte[]? profilesection { get; set; }
        public Guid guid { get; set; }
        public int? idconnectortype { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? f1 { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? f2 { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? a1 { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? b1 { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? c1 { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? d1 { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? e1 { get; set; }
        [Column(TypeName = "numeric(25, 2)")]
        public decimal? a2 { get; set; }
        [Column(TypeName = "numeric(25, 2)")]
        public decimal? b2 { get; set; }
        [Column(TypeName = "numeric(25, 2)")]
        public decimal? c2 { get; set; }
        [Column(TypeName = "numeric(25, 2)")]
        public decimal? d2 { get; set; }
        [Column(TypeName = "numeric(25, 2)")]
        public decimal? e2 { get; set; }
        public int? israck { get; set; }
        public bool? israil { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? system_name { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? modelpart_name { get; set; }
        public int? modelpart_numpos { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? connectortype_name { get; set; }
    }
}
