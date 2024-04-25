using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_docworkpeople
    {
        public int iddocworkpeople { get; set; }
        public int? iddocwork { get; set; }
        public int? idpeople { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(194)]
        [Unicode(false)]
        public string people_fio { get; set; } = null!;
        [StringLength(128)]
        [Unicode(false)]
        public string? people_name { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? people_middlename { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? people_lastname { get; set; }
    }
}
