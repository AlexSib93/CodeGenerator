using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    public partial class actiongroup
    {
        [Key]
        public int idactiongroup { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string name { get; set; } = null!;
    }
}
