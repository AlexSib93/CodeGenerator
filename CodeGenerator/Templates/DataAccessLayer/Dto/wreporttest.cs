using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class wreporttest
    {
        public int id { get; set; }
        public int sensor_id { get; set; }
        [StringLength(500)]
        [Unicode(false)]
        public string value { get; set; } = null!;
        [StringLength(500)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? date { get; set; }
    }
}
