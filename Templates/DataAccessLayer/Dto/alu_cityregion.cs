using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("iddestanation", Name = "idx_alu_cityregion_iddestanation")]
    public partial class alu_cityregion
    {
        [Key]
        public int idaddcityregion { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public int? region { get; set; }
        public int? iddestanation { get; set; }

        [ForeignKey("iddestanation")]
        [InverseProperty("alu_cityregion")]
        public virtual destanation? iddestanationNavigation { get; set; }
    }
}
