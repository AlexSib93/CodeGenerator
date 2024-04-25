using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("dt", "iddestanation", Name = "uniq_destanationplan", IsUnique = true)]
    public partial class destanationplan
    {
        [Key]
        public int iddestanationplan { get; set; }
        [Column(TypeName = "date")]
        public DateTime dt { get; set; }
        public int iddestanation { get; set; }
        public int numpos { get; set; }

        [ForeignKey("iddestanation")]
        [InverseProperty("destanationplan")]
        public virtual destanation iddestanationNavigation { get; set; } = null!;
    }
}
