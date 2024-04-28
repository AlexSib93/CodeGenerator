using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    public partial class tablefiles
    {
        [Key]
        public Guid idtablefiles { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? filename { get; set; }
        [StringLength(10)]
        [Unicode(false)]
        public string? extention { get; set; }
        public byte[]? contents { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? lastdate { get; set; }
    }
}
