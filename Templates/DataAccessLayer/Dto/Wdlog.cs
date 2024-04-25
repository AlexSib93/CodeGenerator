using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idpeople", Name = "idx_wdlog_idpeople")]
    public partial class wdlog
    {
        [Key]
        public int idwdlog { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? code { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string? name { get; set; }
        [Unicode(false)]
        public string? comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? dt { get; set; }
        public int? idpeople { get; set; }

        [ForeignKey("idpeople")]
        [InverseProperty("wdlog")]
        public virtual people? idpeopleNavigation { get; set; }
    }
}
