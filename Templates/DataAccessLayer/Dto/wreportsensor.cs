using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class wreportsensor
    {
        [StringLength(10)]
        [Unicode(false)]
        public string sensor_id { get; set; } = null!;
        public int location_id { get; set; }
    }
}
