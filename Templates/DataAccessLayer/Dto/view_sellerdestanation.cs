﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_sellerdestanation
    {
        public int idsellerdestanation { get; set; }
        public int? idseller { get; set; }
        public int? iddestanation { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? destanation_name { get; set; }
    }
}
