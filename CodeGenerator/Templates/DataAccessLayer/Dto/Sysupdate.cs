using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    public partial class sysupdate
    {
        [Key]
        public int idsysupdate { get; set; }
        [Column(TypeName = "text")]
        public string? script { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dtscript { get; set; }
        [Column(TypeName = "text")]
        public string? comment { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }
    }
}
