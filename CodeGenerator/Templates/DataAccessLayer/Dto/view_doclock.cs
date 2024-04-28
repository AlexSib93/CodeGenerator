using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_doclock
    {
        public int iddoclock { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtlock { get; set; }
        public int? idpeople { get; set; }
        public int? iddoc { get; set; }
        public int? typ { get; set; }
        public int? iddocoper { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        public int? iddocappearance { get; set; }
        [StringLength(194)]
        [Unicode(false)]
        public string? people_fio { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? docappearance_name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? doc_name { get; set; }
    }
}
