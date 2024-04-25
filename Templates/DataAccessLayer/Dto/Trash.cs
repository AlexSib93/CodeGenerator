using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    public partial class trash
    {
        [Key]
        public int idtrash { get; set; }
        [Unicode(false)]
        public string? name { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? value1 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? value2 { get; set; }
    }
}
