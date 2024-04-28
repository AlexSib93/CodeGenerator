using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_sellergrant
    {
        public int idseller { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? sellercode { get; set; }
        public int? idsellergroup { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? discount { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? discount2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? discount3 { get; set; }
        public Guid guid { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? inn { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? kaccount { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? contactpeople { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? phone { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? address { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? bik { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? account { get; set; }
        public int? idaddress { get; set; }
        public int? idcustomer { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? okonh { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? okpo { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? bank { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addint { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addint2 { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? addstr { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? email { get; set; }
        [Column(TypeName = "image")]
        public byte[]? picture { get; set; }
        public int? iddestanation { get; set; }
        public int? idpeople { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? agreename { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? agreedate { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? name2 { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? addresslegal { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? phonemobile { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? directorfio { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? directorfounding { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? addstr1 { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? addstr2 { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? addstr3 { get; set; }
        public int? addint1 { get; set; }
        public int? addint3 { get; set; }
        public int? idaddclassification1 { get; set; }
        public int? idaddclassification2 { get; set; }
        public int? idaddclassification3 { get; set; }
        public int? idaddclassification4 { get; set; }
        public int? idaddclassification5 { get; set; }
        public int? pyrgrouping { get; set; }
        public int? idpreference { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? adddt1 { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? customer_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? destanation_name { get; set; }
        [StringLength(194)]
        [Unicode(false)]
        public string? people_fio { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? addclassification1_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? addclassification2_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? addclassification3_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? addclassification4_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? addclassification5_name { get; set; }
        public int? idsellergrant { get; set; }
        public int idpeoplegroup { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? sellergroup { get; set; }
        public int _grant { get; set; }
    }
}
