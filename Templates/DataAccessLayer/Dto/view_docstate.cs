using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_docstate
    {
        public int iddocstate { get; set; }
        public int? iddocappearance { get; set; }
        public int? numpos { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? comment { get; set; }
        public bool? beginstate { get; set; }
        public bool? endstate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? docappearance_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? docappearance_tablename { get; set; }
    }
}
