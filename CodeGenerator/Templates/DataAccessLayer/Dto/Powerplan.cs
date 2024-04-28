using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idpower", Name = "idx_powerplan_idpower")]
    public partial class powerplan
    {
        [Key]
        public int idpowerplan { get; set; }
        public int? idpower { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? val { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dt { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? workshop1 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? workshop2 { get; set; }
        [Column(TypeName = "numeric(15, 4)")]
        public decimal? workshop3 { get; set; }

        [ForeignKey("idpower")]
        [InverseProperty("powerplan")]
        public virtual power? idpowerNavigation { get; set; }
    }
}
