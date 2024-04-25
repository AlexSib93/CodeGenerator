using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class wreportlocation
    {
        public int id { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string location_name { get; set; } = null!;
    }
}
