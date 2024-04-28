using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class imp_1
    {
        [StringLength(255)]
        public string? marking { get; set; }
        [StringLength(255)]
        public string? name { get; set; }
        [StringLength(255)]
        public string? group { get; set; }
    }
}
