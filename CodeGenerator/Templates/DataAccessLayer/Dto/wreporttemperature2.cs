using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class wreporttemperature2
    {
        public int ID { get; set; }
        [StringLength(500)]
        [Unicode(false)]
        public string val { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime? create_date { get; set; }
    }
}
