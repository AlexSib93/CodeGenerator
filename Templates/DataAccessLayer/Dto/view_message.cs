using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_message
    {
        public int idmessage { get; set; }
        public int? idmessagetype { get; set; }
        [Column(TypeName = "text")]
        public string? messagetext { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dt { get; set; }
        public int? idpeople { get; set; }
        public int? idpeople2 { get; set; }
        public short? isread { get; set; }
        public byte[]? addfile { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? addfilename { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtaction { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtread { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? answer { get; set; }
        public int? iddoc { get; set; }
        public int? iddocappearance { get; set; }
        public bool? check { get; set; }
        public int? iddepartment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcheck { get; set; }
        [Unicode(false)]
        public string? bodytext { get; set; }
        [StringLength(194)]
        [Unicode(false)]
        public string poeple_fio { get; set; } = null!;
        [StringLength(194)]
        [Unicode(false)]
        public string people_fio2 { get; set; } = null!;
        [StringLength(128)]
        [Unicode(false)]
        public string? messagetype_name { get; set; }
    }
}
