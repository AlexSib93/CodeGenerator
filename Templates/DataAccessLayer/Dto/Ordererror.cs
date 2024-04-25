using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("iderror", Name = "idx_ordererror_iderror")]
    [Index("idorder", Name = "idx_ordererror_idorder")]
    [Index("idorderitem", Name = "idx_ordererror_idorderitem")]
    public partial class ordererror
    {
        [Key]
        public int idordererror { get; set; }
        public int? iderror { get; set; }
        public int? idorder { get; set; }
        public int? idorderitem { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        /// <summary>
        /// Часть модели
        /// </summary>
        [StringLength(256)]
        [Unicode(false)]
        public string? modelpart { get; set; }
        [Unicode(false)]
        public string? addinfo { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? addstr1 { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? addstr2 { get; set; }

        [ForeignKey("iderror")]
        [InverseProperty("ordererror")]
        public virtual error? iderrorNavigation { get; set; }
        [ForeignKey("idorder")]
        [InverseProperty("ordererror")]
        public virtual orders? idorderNavigation { get; set; }
        [ForeignKey("idorderitem")]
        [InverseProperty("ordererror")]
        public virtual orderitem? idorderitemNavigation { get; set; }
    }
}
