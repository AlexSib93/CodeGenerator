using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    public partial class sysinfo
    {
        [Key]
        public int idsysinfo { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? name { get; set; }
        [StringLength(32)]
        [Unicode(false)]
        public string? value { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dt { get; set; }
    }
}
