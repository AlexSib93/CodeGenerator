using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    public partial class wreportworks
    {
        [Key]
        public int idwork { get; set; }
        [Unicode(false)]
        public string? name { get; set; }
    }
}
