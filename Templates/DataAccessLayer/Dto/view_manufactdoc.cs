using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_manufactdoc
    {
        public int idmanufactdoc { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtdoc { get; set; }
        public int? idpeople { get; set; }
        public int? qupos { get; set; }
        public int? idmanufactdocgroup { get; set; }
        public int? iddocoper { get; set; }
        public int? flownum { get; set; }
        public int? idpeopleedit { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcreate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtedit { get; set; }
        public int? qugroup { get; set; }
        public int? shiftnum { get; set; }
        public int? workshopnum { get; set; }
        public int? partnum { get; set; }
        public int? iddocstate { get; set; }
        [Column("class")]
        public byte[]? _class { get; set; }
        public int? idcustomer { get; set; }
        [StringLength(194)]
        [Unicode(false)]
        public string? people_fio { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? docoper_name { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? docstate_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? customer_name { get; set; }
    }
}
