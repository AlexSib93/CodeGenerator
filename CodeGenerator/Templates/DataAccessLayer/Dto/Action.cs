using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    public partial class action
    {
        [Key]
        public int idaction { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string name { get; set; } = null!;
    }
}
