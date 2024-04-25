using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_supplydoc
    {
        public int idsupplydoc { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtdoc { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcre { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? idpeople { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smdoc { get; set; }
        public int? iddocoper { get; set; }
        public int? idcustomer { get; set; }
        public int? idsupplydocgroup { get; set; }
        public int? idorder { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? addstr1 { get; set; }
        public int? iddocstate { get; set; }
        public int? idcustomer2 { get; set; }
        public int? idvalut { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? valutrate { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase { get; set; }
        public bool withnds { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sumnds { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? nds { get; set; }
        public int? idseller { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? docoper_name { get; set; }
        [StringLength(194)]
        [Unicode(false)]
        public string? people_fio { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? customer_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? customer2_name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? order_agreedate { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? order_agreename { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? order_name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? order_date { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? docstate_name { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? valut_shortname { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? seller_name { get; set; }
    }
}
