using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_docscriptgrant
    {
        public int iddocscriptgrant { get; set; }
        public int? iddocscript { get; set; }
        public int? idpeoplegroup { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? iddocappearance { get; set; }
        public Guid guid { get; set; }
        [Unicode(false)]
        public string? docscript_name { get; set; }
        [Unicode(false)]
        public string? docscript_comment { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? docscript_groupname { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? docappearance_name { get; set; }
    }
}
