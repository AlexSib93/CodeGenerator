﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Keyless]
    public partial class view_addarea
    {
        public int idaddarea { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public Guid guid { get; set; }
        public int? idaddregion { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? region_name { get; set; }
        public int? postindex { get; set; }
    }
}