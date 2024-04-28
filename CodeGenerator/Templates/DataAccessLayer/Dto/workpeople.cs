using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idpeople", Name = "idx_workpeople_idpeople")]
    [Index("idwork", Name = "idx_workpeople_idwork")]
    public partial class workpeople
    {
        [Key]
        public int idworkpeople { get; set; }
        public int? idwork { get; set; }
        public int? idpeople { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public Guid guid { get; set; }

        [ForeignKey("idpeople")]
        [InverseProperty("workpeople")]
        public virtual people? idpeopleNavigation { get; set; }
        [ForeignKey("idwork")]
        [InverseProperty("workpeople")]
        public virtual work? idworkNavigation { get; set; }
    }
}
