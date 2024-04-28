using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class pg_lamin_condition
    {
        [StringLength(128)]
        [Unicode(false)]
        public string? color_marking { get; set; }
        [StringLength(256)]
        public string? color_name { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? addprice { get; set; }
    }
}
