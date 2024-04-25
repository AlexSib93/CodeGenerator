using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_customer
    {
        public int idcustomer { get; set; }
        public int? idcustomergroup { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? inn { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? okonh { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? okpo { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? web { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? address { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? bik { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? account { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? kaccount { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? contactpeople { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? phone { get; set; }
        public int? face { get; set; }
        public short? typ { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "text")]
        public string? comment { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? discount { get; set; }
        public int? iddestanation { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? credit { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? discount2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? discount3 { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? directorfio { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? directorfounding { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? firstname { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? middlename { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? lastname { get; set; }
        public int? idaddress { get; set; }
        [StringLength(10)]
        [Unicode(false)]
        public string? passportseries { get; set; }
        [StringLength(10)]
        [Unicode(false)]
        public string? passportnum { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? passportexit { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? passportdate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? birthday { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? phonemobile { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? phonehome { get; set; }
        public int? idaddresslegal { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? addresslegal { get; set; }
        public int? idsourceinfo { get; set; }
        public int? idaw { get; set; }
        public int? idseller { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? bank { get; set; }
        public Guid guid { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? email { get; set; }
        public int? idcustomercategory { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? name2 { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? name3 { get; set; }
        public int? idcustomerform { get; set; }
        public int? idpeople { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? ogrn { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? discount4 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? discount5 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? discount6 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? discount7 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? discount8 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? discount9 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? discount10 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? discount11 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? discount12 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcre { get; set; }
        public int? idpeoplecre { get; set; }
        public int? iddocoper { get; set; }
        [Unicode(false)]
        public string? addstr { get; set; }
        [Unicode(false)]
        public string? addstr2 { get; set; }
        [Unicode(false)]
        public string? addstr3 { get; set; }
        [Unicode(false)]
        public string? addstr4 { get; set; }
        [Unicode(false)]
        public string? addstr5 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addnum { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addnum2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addnum3 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addnum4 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addnum5 { get; set; }
        public int? addint { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? directorposition { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? auditorfio { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtbirth { get; set; }
        [StringLength(4)]
        [Unicode(false)]
        public string? passportserial { get; set; }
        public int? passportnumber { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? passportdtissue { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? passportissued { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? contact { get; set; }
        public int? parentid { get; set; }
        public int? iddocstate { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string? kpp { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string? okato { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? phone2 { get; set; }
        public int? idaddclassification1 { get; set; }
        public int? idaddclassification2 { get; set; }
        public int? idaddclassification3 { get; set; }
        public int? idaddclassification4 { get; set; }
        public int? idaddclassification5 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtdoc { get; set; }
        public bool? addbit1 { get; set; }
        public bool? addbit2 { get; set; }
        public bool? indealerbase { get; set; }
        public int? idagreement { get; set; }
        public int? idpeople2 { get; set; }
        public int? idpeople3 { get; set; }
        public int? idpeople4 { get; set; }
        public int? idvalut { get; set; }
        [StringLength(194)]
        [Unicode(false)]
        public string people_name { get; set; } = null!;
        [StringLength(194)]
        [Unicode(false)]
        public string peoplecre_name { get; set; } = null!;
        [StringLength(194)]
        [Unicode(false)]
        public string people2_fio { get; set; } = null!;
        [StringLength(194)]
        [Unicode(false)]
        public string people3_fio { get; set; } = null!;
        [StringLength(194)]
        [Unicode(false)]
        public string people4_fio { get; set; } = null!;
        [StringLength(9)]
        [Unicode(false)]
        public string typ_name { get; set; } = null!;
        [StringLength(9)]
        [Unicode(false)]
        public string face_name { get; set; } = null!;
        [StringLength(128)]
        [Unicode(false)]
        public string? destanation_name { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? account_rs { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? account_ks { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? account_bank { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? account_bik { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? account_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? sourceinfo_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? seller_name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? customercategory_name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? customerform_name { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? docoper_name { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? docstate_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? parentcustomer_name { get; set; }
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
        [StringLength(128)]
        [Unicode(false)]
        public string? agreement_name { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? valut_shortname { get; set; }
    }
}
