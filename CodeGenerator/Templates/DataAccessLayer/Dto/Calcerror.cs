using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("iderror", Name = "idx_calcerror_iderror")]
    public partial class calcerror
    {
        [Key]
        public int idcalcerror { get; set; }
        public int? iderror { get; set; }
        [StringLength(128)]
        [Unicode(false)]
        public string? name { get; set; }

        [ForeignKey("iderror")]
        [InverseProperty("calcerror")]
        public virtual error? iderrorNavigation { get; set; }
    }
}
