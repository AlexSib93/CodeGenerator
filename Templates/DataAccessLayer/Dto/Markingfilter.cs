using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    public partial class markingfilter
    {
        [Key]
        public int idmarkingfilter { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string name { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int idmarkingfiltertype { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
    }
}
