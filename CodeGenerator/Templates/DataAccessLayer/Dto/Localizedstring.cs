using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    public partial class localizedstring
    {
        [Key]
        public int idlocalizedstring { get; set; }
        [StringLength(256)]
        public string code { get; set; } = null!;
        public int? type { get; set; }
        public string? default_val { get; set; }
        public string? locale_val { get; set; }
    }
}
