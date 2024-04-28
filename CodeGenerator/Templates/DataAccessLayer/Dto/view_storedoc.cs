using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_storedoc
    {
        public int idstoredoc { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? idpeople { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? logincre { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtdoc { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcre { get; set; }
        public int? qupos { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smdoc { get; set; }
        public int? idcustomer { get; set; }
        public int? idstoredocgroup { get; set; }
        public int? idstoredepart1 { get; set; }
        public int? idstoredepart2 { get; set; }
        public int? iddocoper { get; set; }
        public int? idvalut { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? valutrate { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? pricebase { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? smbase { get; set; }
        public int? iddocstate { get; set; }
        public bool? reg { get; set; }
        public int? idorder { get; set; }
        public bool withnds { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sumnds { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? nds { get; set; }
        public int? idseller { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? outname { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? outdate { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? valut_shortname { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? docoper_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? storedepart_name1 { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? storedepart_name2 { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? customer_name { get; set; }
        [StringLength(194)]
        [Unicode(false)]
        public string? people_fio { get; set; }
        public short? docoper_storetyp { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? docstate_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? seller_name { get; set; }
    }
}
