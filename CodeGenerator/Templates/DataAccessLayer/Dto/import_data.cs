using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    [Table("import-data")]
    public partial class import_data
    {
        [StringLength(255)]
        public string? F1 { get; set; }
        [StringLength(255)]
        public string? F2 { get; set; }
        [StringLength(255)]
        public string? F3 { get; set; }
        public double? F4 { get; set; }
        public double? F5 { get; set; }
        public double? F6 { get; set; }
        public double? F7 { get; set; }
        public double? F8 { get; set; }
        [StringLength(255)]
        public string? F9 { get; set; }
        public double? F10 { get; set; }
        [StringLength(255)]
        public string? F11 { get; set; }
    }
}
