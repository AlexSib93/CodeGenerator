using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_servicedocpos
    {
        public int idservicedocpos { get; set; }
        public int? idservicedoc { get; set; }
        public int? numpos { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? idservicereason { get; set; }
        public int? idpeople { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dt { get; set; }
        public int? idorderitem { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? qu { get; set; }
        public int? addint1 { get; set; }
        public int? addint2 { get; set; }
        public int? addint3 { get; set; }
        public int? addint4 { get; set; }
        public int? addint5 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addnum1 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addnum2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addnum3 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addnum4 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addnum5 { get; set; }
        [StringLength(59)]
        [Unicode(false)]
        public string? addstr1 { get; set; }
        [Unicode(false)]
        public string? addstr2 { get; set; }
        [Unicode(false)]
        public string? addstr3 { get; set; }
        [Unicode(false)]
        public string? addstr4 { get; set; }
        [Unicode(false)]
        public string? addstr5 { get; set; }
        [StringLength(194)]
        [Unicode(false)]
        public string? people_fio { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? reason_name { get; set; }
        public int? orderitem_numpos { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? orderitem_name { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? size { get; set; }
        public byte[]? picture { get; set; }
        public int? orderitemnum { get; set; }
    }
}
