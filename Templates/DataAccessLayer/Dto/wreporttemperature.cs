using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class wreporttemperature
    {
        public int id { get; set; }
        [StringLength(10)]
        [Unicode(false)]
        public string sensor_id { get; set; } = null!;
        public int mount_location { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? sensor_value { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? date { get; set; }
        [StringLength(500)]
        [Unicode(false)]
        public string? comment { get; set; }
    }
}
