using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_errorgroup
    {
        public int iderrorgroup { get; set; }
        public int? parentid { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? name { get; set; }
        [Unicode(false)]
        public string? comment { get; set; }
        public Guid guid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
    }
}
