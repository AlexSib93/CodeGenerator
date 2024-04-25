using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_valutrate
    {
        public int idvalutrate { get; set; }
        public int? idvalut { get; set; }
        public int? idvalut2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dt { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? valut_shortname { get; set; }
        [StringLength(16)]
        [Unicode(false)]
        public string? valut_shortname2 { get; set; }
    }
}
