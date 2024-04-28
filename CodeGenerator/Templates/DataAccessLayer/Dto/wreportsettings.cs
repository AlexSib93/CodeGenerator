using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class wreportsettings
    {
        public int idsettings { get; set; }
        public int? idpeople { get; set; }
        [StringLength(500)]
        [Unicode(false)]
        public string name { get; set; } = null!;
        [StringLength(500)]
        [Unicode(false)]
        public string data { get; set; } = null!;
    }
}
