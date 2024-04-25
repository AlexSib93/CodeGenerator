using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_actionhistory
    {
        public int idactionhistory { get; set; }
        public int idaction { get; set; }
        public int idactiongroup { get; set; }
        public int? idpeople { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtcre { get; set; }
        public int? addint1 { get; set; }
        public int? addint2 { get; set; }
        public int? addint3 { get; set; }
        public int? addint4 { get; set; }
        public int? addint5 { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal? addnum1 { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal? addnum2 { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal? addnum3 { get; set; }
        [Unicode(false)]
        public string? addstr1 { get; set; }
        [Unicode(false)]
        public string? addstr2 { get; set; }
        [Unicode(false)]
        public string? addstr3 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? adddate1 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? adddate2 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? adddate3 { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? actiongroup_name { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? action_name { get; set; }
        [StringLength(194)]
        [Unicode(false)]
        public string? fio { get; set; }
    }
}
