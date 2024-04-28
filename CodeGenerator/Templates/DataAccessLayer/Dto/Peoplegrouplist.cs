using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Dto
{
    [Index("idpeople", Name = "idx_peoplegrouplist_idpeople")]
    [Index("idpeoplegroup", Name = "idx_peoplegrouplist_idpeoplegroup")]
    public partial class peoplegrouplist
    {
        [Key]
        public int idpeoplegrouplist { get; set; }
        public int? idpeople { get; set; }
        public int? idpeoplegroup { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? deleted { get; set; }
        public Guid guid { get; set; }

        [ForeignKey("idpeople")]
        [InverseProperty("peoplegrouplist")]
        public virtual people? idpeopleNavigation { get; set; }
        [ForeignKey("idpeoplegroup")]
        [InverseProperty("peoplegrouplist")]
        public virtual peoplegroup? idpeoplegroupNavigation { get; set; }
    }
}
