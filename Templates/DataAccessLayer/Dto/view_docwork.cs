using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_docwork
    {
        public int iddocwork { get; set; }
        public int iddoc { get; set; }
        public int iddocappearance { get; set; }
        public int? idwork { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? qu { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? worktime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? idpeople { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtwork { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm { get; set; }
        public int? idworkoper { get; set; }
        public int? iddocitem { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcreate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtedit { get; set; }
        public int? idpeopleedit { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? price { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? work_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? workoper_name { get; set; }
        [StringLength(194)]
        [Unicode(false)]
        public string? people_fio { get; set; }
        [StringLength(194)]
        [Unicode(false)]
        public string? peopleedit_fio { get; set; }
    }
}
