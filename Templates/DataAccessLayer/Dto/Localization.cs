using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    public partial class localization
    {
        [Key]
        [StringLength(256)]
        [Unicode(false)]
        public string formname { get; set; } = null!;
        [Column(TypeName = "xml")]
        public string? data { get; set; }
        [StringLength(64)]
        [Unicode(false)]
        public string? version { get; set; }
    }
}
