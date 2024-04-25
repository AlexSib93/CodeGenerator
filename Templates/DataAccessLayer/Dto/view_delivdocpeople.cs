using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_delivdocpeople
    {
        public int iddelivdocpeople { get; set; }
        public int? iddelivdoc { get; set; }
        public int? idpeople { get; set; }
        public int? idpeople2 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dt { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dt2 { get; set; }
        [StringLength(194)]
        [Unicode(false)]
        public string? people_fio { get; set; }
        [StringLength(194)]
        [Unicode(false)]
        public string? people2_fio { get; set; }
    }
}
