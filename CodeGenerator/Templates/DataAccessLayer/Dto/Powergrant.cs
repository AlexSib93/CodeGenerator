using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idpeoplegroup", Name = "idx_powergrant_idpeoplegroup")]
    [Index("idpower", Name = "idx_powergrant_idpower")]
    public partial class powergrant
    {
        [Key]
        public int idpowergrant { get; set; }
        public int? idpower { get; set; }
        public int? idpeoplegroup { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }

        [ForeignKey("idpeoplegroup")]
        [InverseProperty("powergrant")]
        public virtual peoplegroup? idpeoplegroupNavigation { get; set; }
        [ForeignKey("idpower")]
        [InverseProperty("powergrant")]
        public virtual power? idpowerNavigation { get; set; }
    }
}
