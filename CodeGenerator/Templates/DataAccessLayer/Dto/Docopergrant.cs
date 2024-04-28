using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("iddocoper", Name = "idx_docopergrant_iddocoper")]
    [Index("idpeoplegroup", Name = "idx_docopergrant_idpeoplegroup")]
    public partial class docopergrant
    {
        [Key]
        public int iddocopergrant { get; set; }
        public int? iddocoper { get; set; }
        public int? idpeoplegroup { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public Guid guid { get; set; }

        [ForeignKey("iddocoper")]
        [InverseProperty("docopergrant")]
        public virtual docoper? iddocoperNavigation { get; set; }
        [ForeignKey("idpeoplegroup")]
        [InverseProperty("docopergrant")]
        public virtual peoplegroup? idpeoplegroupNavigation { get; set; }
    }
}
