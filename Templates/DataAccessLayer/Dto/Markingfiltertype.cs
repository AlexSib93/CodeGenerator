using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    public partial class markingfiltertype
    {
        [Key]
        public int idmarkingfiltertype { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string name { get; set; } = null!;
    }
}
