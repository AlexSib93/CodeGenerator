using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idvalut", Name = "idx_valutrate_idvalut")]
    [Index("idvalut2", Name = "idx_valutrate_idvalut2")]
    public partial class valutrate
    {
        [Key]
        public int idvalutrate { get; set; }
        public int? idvalut { get; set; }
        public int? idvalut2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? sm { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dt { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }

        [ForeignKey("idvalut2")]
        [InverseProperty("valutrateidvalut2Navigation")]
        public virtual valut? idvalut2Navigation { get; set; }
        [ForeignKey("idvalut")]
        [InverseProperty("valutrateidvalutNavigation")]
        public virtual valut? idvalutNavigation { get; set; }
    }
}
